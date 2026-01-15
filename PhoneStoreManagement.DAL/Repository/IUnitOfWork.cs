using PhoneStoreManagement.Data.Repository;

namespace PhoneStoreManagement.Data;

public interface IUnitOfWork
{
    IProductRepository Products { get; }
    ISupplierRepository Suppliers { get; }
    ICustomerRepository Customers { get; }
    IInvoiceRepository Invoices { get; }
    IWarrantyRepository Warranties { get; }

    Task<int> SaveChangesAsync(CancellationToken ct = default);
}
