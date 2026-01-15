using PhoneStoreManagement.Data.Repository;

namespace PhoneStoreManagement.Data { 

public class UnitOfWork : IUnitOfWork
    {
    private readonly PhoneDbContext _db;

    public UnitOfWork(PhoneDbContext db)
    {
        _db = db;

        Products = new ProductRepository(_db);
        Suppliers = new SupplierRepository(_db);
        Customers = new CustomerRepository(_db);
        Invoices = new InvoiceRepository(_db);
        Warranties = new WarrantyRepository(_db);
    }

    public IProductRepository Products { get; }
    public ISupplierRepository Suppliers { get; }
    public ICustomerRepository Customers { get; }
    public IInvoiceRepository Invoices { get; }
    public IWarrantyRepository Warranties { get; }

    public Task<int> SaveChangesAsync(CancellationToken ct = default)
        => _db.SaveChangesAsync(ct);
}
}