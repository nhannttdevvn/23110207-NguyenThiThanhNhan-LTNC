using Microsoft.EntityFrameworkCore;
using PhoneStoreManagement.Entity.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PhoneStoreManagement.Data.Repository;

public class WarrantyRepository : RepositoryBase<Warranty>, IWarrantyRepository
{
    public WarrantyRepository(PhoneDbContext db) : base(db) { }

    public async Task<List<Warranty>> LookupAsync(string keyword, CancellationToken ct = default)
    {
        try
        {
            var key = (keyword ?? "").Trim();

            var q = Db.Warranties
                .Include(x => x.InvoiceItem)
                    .ThenInclude(ii => ii.Product)
                .Include(x => x.InvoiceItem)
                    .ThenInclude(ii => ii.Invoice)
                .AsNoTracking();

            if (string.IsNullOrEmpty(key))
            {
                return await q.OrderByDescending(x => x.EndDate).ToListAsync(ct);
            }

            int.TryParse(key, out int id);

            return await q.Where(x => x.WarrantyId == id || x.CustomerPhone.Contains(key))
                          .OrderByDescending(x => x.EndDate)
                          .ToListAsync(ct);
        }
        catch
        {
            return new List<Warranty>();
        }
    }
}