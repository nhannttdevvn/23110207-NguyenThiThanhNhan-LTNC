using Microsoft.EntityFrameworkCore;
using PhoneStoreManagement.Entity.Entities;

namespace PhoneStoreManagement.Data;

public class SupplierRepository : ISupplierRepository
{
    private readonly PhoneDbContext _db;

    public SupplierRepository(PhoneDbContext db)
    {
        _db = db;
    }

    public IQueryable<Supplier> GetAll()
        => _db.Suppliers.AsQueryable();

    public async Task<List<Supplier>> SearchAsync(string keyword, CancellationToken ct = default)
        => await _db.Suppliers
            .Where(x => x.SupplierName.Contains(keyword))
            .ToListAsync(ct);

    public async Task<Supplier?> GetByIdAsync(int id, CancellationToken ct = default) // ✅ THÊM
        => await _db.Suppliers.FirstOrDefaultAsync(x => x.SupplierId == id, ct);

    public async Task AddAsync(Supplier supplier, CancellationToken ct = default)
        => await _db.Suppliers.AddAsync(supplier, ct);

    public void Update(Supplier supplier)
        => _db.Suppliers.Update(supplier);

    public void Delete(Supplier supplier)
        => _db.Suppliers.Remove(supplier);
    public void Remove(Supplier supplier)
       => _db.Suppliers.Remove(supplier);
}
