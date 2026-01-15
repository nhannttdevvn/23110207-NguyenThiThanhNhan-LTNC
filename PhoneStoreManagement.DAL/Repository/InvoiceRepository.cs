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

    public Task<List<Invoice>> SearchAsync(string keyword, CancellationToken ct = default)
    {
        keyword = (keyword ?? "").Trim().ToLower();
        var q = Db.Invoices
            .Include(x => x.Supplier)
            .Include(x => x.Customer)
            .AsNoTracking()
            .AsQueryable();

        if (keyword.Length > 0)
        {
            q = q.Where(x =>
                x.InvoiceNo.ToLower().Contains(keyword) ||
                x.Status.ToLower().Contains(keyword));
        }

        return q.OrderByDescending(x => x.InvoiceDate).ToListAsync(ct);
    }
}

