using Microsoft.EntityFrameworkCore;
using PhoneStoreManagement.Data;
using PhoneStoreManagement.Entity.Entities;
using PhoneStoreManagement.Services.Interfaces;

namespace PhoneStoreManagement.Services.Implementations;

public class ProductService : IProductService
{
    private readonly PhoneDbContext _db;

    public ProductService(PhoneDbContext db)
    {
        _db = db;
    }

    // ===== SINH MÃ CHUẨN =====
    private async Task<string> GenerateCodeAsync(CancellationToken ct)
    {
        var lastCode = await _db.Products
            .OrderByDescending(x => x.ProductId)
            .Select(x => x.ProductCode)
            .FirstOrDefaultAsync(ct);

        if (string.IsNullOrEmpty(lastCode))
            return "P000001";

        var number = int.Parse(lastCode.Substring(1));
        return $"P{(number + 1):D6}";
    }

    public async Task<int> CreateAsync(Product p, CancellationToken ct = default)
    {
        p.ProductCode = await GenerateCodeAsync(ct);

        _db.Products.Add(p);
        await _db.SaveChangesAsync(ct);
        return p.ProductId;
    }

    public Task<Product?> GetAsync(int id, CancellationToken ct = default)
        => _db.Products.FindAsync(new object[] { id }, ct).AsTask();

    public Task<Product?> GetByCodeAsync(string code, CancellationToken ct = default)
        => _db.Products.FirstOrDefaultAsync(x => x.ProductCode == code, ct);

    public async Task<List<Product>> SearchAsync(string keyword, CancellationToken ct = default)
    {
        keyword ??= "";

        return await _db.Products
    .Include(x => x.Supplier)
    .AsNoTracking()
    .Where(x => x.ProductName.Contains(keyword))
    .ToListAsync(ct);


    }

    public async Task UpdateAsync(Product p, CancellationToken ct = default)
    {
        var tracked = _db.ChangeTracker
            .Entries<Product>()
            .FirstOrDefault(e => e.Entity.ProductId == p.ProductId);

        if (tracked != null)
            tracked.State = EntityState.Detached;

        _db.Products.Attach(p);
        _db.Entry(p).State = EntityState.Modified;


        await _db.SaveChangesAsync(ct);
    }


    public async Task DeleteAsync(int id, CancellationToken ct = default)
    {
        var p = await _db.Products.FindAsync(new object[] { id }, ct);
        if (p == null) return;

        _db.Products.Remove(p);
        await _db.SaveChangesAsync(ct);
    }
}
