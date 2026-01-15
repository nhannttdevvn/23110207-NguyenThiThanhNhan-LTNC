using PhoneStoreManagement.Entity.Entities;

namespace PhoneStoreManagement.Data;

public interface ISupplierRepository
{
    IQueryable<Supplier> GetAll();
    Task<List<Supplier>> SearchAsync(string keyword, CancellationToken ct = default);

    Task<Supplier?> GetByIdAsync(int id, CancellationToken ct = default); // ✅ THÊM

    Task AddAsync(Supplier supplier, CancellationToken ct = default);
    void Update(Supplier supplier);
    void Delete(Supplier supplier);
    void Remove(Supplier supplier);
}
