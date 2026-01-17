using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using PhoneStoreManagement.Entity.Entities;

namespace PhoneStoreManagement.Data.Repository;

public class InvoiceRepository : RepositoryBase<Invoice>, IInvoiceRepository
{
    public InvoiceRepository(PhoneDbContext db) : base(db) { }

    public Task<Invoice?> GetDetailAsync(int invoiceId, CancellationToken ct = default)
        => Db.Invoices
            .Include(x => x.InvoiceItems).ThenInclude(i => i.Product)
            .Include(x => x.Supplier)
            .Include(x => x.Customer)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.InvoiceId == invoiceId, ct);

    public async Task<List<Invoice>> SearchAsync(string keyword, CancellationToken ct = default)
    {
        keyword = (keyword ?? "").Trim().ToLower();

        var q = Db.Invoices
            .Include(x => x.Supplier)
            .Include(x => x.Customer)
            .Include(x => x.Employee)
            .AsNoTracking()
            .AsQueryable();

        if (!string.IsNullOrEmpty(keyword))
        {
            q = q.Where(x =>
                //x.InvoiceId.ToString().Contains(keyword) || // ✅ Tìm kiếm theo ID (kiểu số)
                x.InvoiceNo.ToLower().Contains(keyword) ||  // Tìm theo Mã đơn hàng (chuỗi)
                x.Customer.FullName.ToLower().Contains(keyword)); // Tìm theo Tên khách hàng
        }

        return await q.OrderByDescending(x => x.InvoiceDate).ToListAsync(ct);
    }
}