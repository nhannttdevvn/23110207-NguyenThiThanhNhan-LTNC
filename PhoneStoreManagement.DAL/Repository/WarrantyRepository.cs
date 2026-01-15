using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using PhoneStoreManagement.Entity.Entities;

namespace PhoneStoreManagement.Data.Repository;

public class WarrantyRepository : RepositoryBase<Warranty>, IWarrantyRepository
{
    public WarrantyRepository(PhoneDbContext db) : base(db) { }

    public Task<List<Warranty>> LookupAsync(string phoneOrWarrantyNo, CancellationToken ct = default)
    {
        var key = (phoneOrWarrantyNo ?? "").Trim();

        var q = Db.Warranties
            .Include(x => x.Customer)
            .Include(x => x.Product)
            .Include(x => x.InvoiceItem).ThenInclude(ii => ii!.Invoice)
            .AsNoTracking()
            .AsQueryable();

        if (key.Length == 0) return Task.FromResult(new List<Warranty>());

        q = q.Where(x => x.WarrantyNo == key || (x.Customer != null && x.Customer.Phone == key));
        return q.OrderByDescending(x => x.EndDate).ToListAsync(ct);
    }
}
