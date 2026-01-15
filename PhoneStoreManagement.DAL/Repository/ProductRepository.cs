using Microsoft.EntityFrameworkCore;
using PhoneStoreManagement.Entity.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PhoneStoreManagement.Data.Repository;

public class ProductRepository : RepositoryBase<Product>, IProductRepository
{
    public ProductRepository(PhoneDbContext db) : base(db) { }

  


    public Task<List<Product>> SearchAsync(string keyword, CancellationToken ct = default)
    {
        keyword = (keyword ?? "").Trim().ToLower();

        IQueryable<Product> q = Db.Products.AsNoTracking();

        if (!string.IsNullOrEmpty(keyword))
        {
            q = q.Where(x =>
                x.ProductCode.ToLower().Contains(keyword) ||
                x.ProductName.ToLower().Contains(keyword) ||
                x.Brand.ToLower().Contains(keyword) ||
                x.Variant.ToLower().Contains(keyword) ||
                x.Origin.ToLower().Contains(keyword)
            );
        }

        return q
            .OrderBy(x => x.ProductName)
            .ToListAsync(ct);
    }
    public IQueryable<Product> GetAll()
        => Db.Products.AsQueryable();
}
