using ClosedXML.Excel;
using Microsoft.EntityFrameworkCore;
using PhoneStoreManagement.Data;
using PhoneStoreManagement.Entity.Entities;
using PhoneStoreManagement.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PhoneStoreManagement.Services.Implementations
{
    public class ReportService : IReportService
    {
        private readonly PhoneDbContext _db;

        public ReportService(PhoneDbContext db)
        {
            _db = db;
        }

        public async Task<List<Invoice>> GetInvoicesAsync(
            string keyword = "",
            DateTime? fromDate = null,
            DateTime? toDate = null,
            CancellationToken ct = default)
        {
            var query = _db.Invoices
                .Include(x => x.Customer)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                query = query.Where(x =>
                    x.InvoiceCode.Contains(keyword) ||
                    x.Customer.FullName.Contains(keyword));
            }

            if (fromDate.HasValue)
                query = query.Where(x => x.InvoiceDate >= fromDate.Value);

            if (toDate.HasValue)
                query = query.Where(x => x.InvoiceDate <= toDate.Value);

            return await query.ToListAsync(ct);
        }

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
        public async Task<Invoice> GetInvoiceDetailAsync(int invoiceId)
        {
            return await _db.Invoices
                .Include(x => x.Customer)
                .Include(x => x.Employee)
                .Include(x => x.InvoiceItems)
                    .ThenInclude(i => i.Product)
                .FirstAsync(x => x.InvoiceId == invoiceId);
        }

        public byte[] ExportInvoiceExcelBytes(List<Invoice> invoices)
        {
            using var wb = new XLWorkbook();
            var ws = wb.Worksheets.Add("Invoices");

            ws.Cell(1, 1).Value = "Mã HĐ";
            ws.Cell(1, 2).Value = "Khách hàng";
            ws.Cell(1, 3).Value = "Địa chỉ";
            ws.Cell(1, 4).Value = "Ngày mua";
            ws.Cell(1, 5).Value = "Nhân viên";
            ws.Cell(1, 6).Value = "Tổng tiền";

            int row = 2;
            foreach (var i in invoices)
            {
                ws.Cell(row, 1).Value = i.InvoiceCode;
                ws.Cell(row, 2).Value = i.Customer?.FullName;
                ws.Cell(row, 3).Value = i.Customer?.Address;
                ws.Cell(row, 4).Value = i.InvoiceDate;
                ws.Cell(row, 5).Value = i.EmployeeId;
                ws.Cell(row, 6).Value = i.TotalAmount;
                row++;
            }

            ws.Columns().AdjustToContents();

            using var ms = new MemoryStream();
            wb.SaveAs(ms);
            return ms.ToArray();
        }

    }
}
