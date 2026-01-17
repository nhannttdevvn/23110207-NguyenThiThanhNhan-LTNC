using ClosedXML.Excel;
using Microsoft.EntityFrameworkCore;
using PhoneStoreManagement.Data;
using PhoneStoreManagement.Data.Repository;
using PhoneStoreManagement.Entity.Entities;
using PhoneStoreManagement.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PhoneStoreManagement.Services.Implementations;

public class ReportService : IReportService
{
    private readonly PhoneDbContext _db;
    private readonly IInvoiceRepository _invoiceRepository;

    public ReportService(PhoneDbContext db, IInvoiceRepository invoiceRepository)
    {
        _db = db;
        _invoiceRepository = invoiceRepository;
    }

    // 1. Lấy danh sách hóa đơn (Có Include đầy đủ để tránh lỗi Null)
    public async Task<List<Invoice>> GetInvoicesAsync(
        string keyword = "",
        DateTime? fromDate = null,
        DateTime? toDate = null,
        CancellationToken ct = default)
    {
        // 1. Gọi tầng DAL để lấy dữ liệu đã lọc theo từ khóa
        var invoices = await _invoiceRepository.SearchAsync(keyword, ct);

        // 2. Tầng BLL xử lý logic nghiệp vụ bổ sung (Lọc theo ngày)
        var filteredQuery = invoices.AsQueryable();

        if (fromDate.HasValue)
            filteredQuery = filteredQuery.Where(x => x.InvoiceDate >= fromDate.Value);

        if (toDate.HasValue)
            filteredQuery = filteredQuery.Where(x => x.InvoiceDate <= toDate.Value);

        return filteredQuery.ToList();
    }

    // 2. Tính tổng doanh thu
    public async Task<decimal> GetTotalRevenueAsync(
        DateTime? fromDate = null,
        DateTime? toDate = null,
        CancellationToken ct = default)
    {
        var query = _db.Invoices.AsQueryable();

        if (fromDate.HasValue)
            query = query.Where(x => x.InvoiceDate >= fromDate.Value);

        if (toDate.HasValue)
            query = query.Where(x => x.InvoiceDate <= toDate.Value);

        return await query.SumAsync(x => x.TotalAmount, ct);
    }

    // 3. Lấy chi tiết một hóa đơn (Giải quyết lỗi thiếu Member)
    public async Task<Invoice> GetInvoiceDetailAsync(int invoiceId)
    {
        var invoice = await _db.Invoices
            .Include(x => x.Customer)
            .Include(x => x.Employee)
            .Include(x => x.InvoiceItems)
                .ThenInclude(ii => ii.Product)
            .FirstOrDefaultAsync(x => x.InvoiceId == invoiceId);

        return invoice!; // Trả về invoice (nếu null sẽ bắn lỗi ở tầng UI khi gọi)
    }

    // 4. Xuất file Excel
    public byte[] ExportInvoiceExcelBytes(List<Invoice> invoices)
    {
        using var wb = new XLWorkbook();
        var ws = wb.Worksheets.Add("Invoices");

        // Header
        string[] headers = { "Mã HĐ", "Khách hàng", "Địa chỉ", "Ngày mua", "Nhân viên", "Tổng tiền" };
        for (int i = 0; i < headers.Length; i++)
        {
            ws.Cell(1, i + 1).Value = headers[i];
            ws.Cell(1, i + 1).Style.Font.Bold = true;
        }

        // Data
        int row = 2;
        foreach (var i in invoices)
        {
            ws.Cell(row, 1).Value = i.InvoiceCode;
            ws.Cell(row, 2).Value = i.Customer?.FullName ?? "N/A";
            ws.Cell(row, 3).Value = i.Customer?.Address ?? "N/A";
            ws.Cell(row, 4).Value = i.InvoiceDate.ToString("dd/MM/yyyy HH:mm");
            ws.Cell(row, 5).Value = i.Employee?.FullName ?? "N/A"; // Lấy tên thay vì lấy ID
            ws.Cell(row, 6).Value = i.TotalAmount;
            ws.Cell(row, 6).Style.NumberFormat.Format = "#,##0";
            row++;
        }

        ws.Columns().AdjustToContents();

        using var ms = new MemoryStream();
        wb.SaveAs(ms);
        return ms.ToArray();
    }
}