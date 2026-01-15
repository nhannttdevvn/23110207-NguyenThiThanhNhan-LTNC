using PhoneStoreManagement.Entity.Entities;

namespace PhoneStoreManagement.Services.Interfaces;

public interface IInvoiceService
{
    Task CreateOrderAsync(
        string customerName,
        string phone,
        string address,
        int employeeId,
        List<(int productId, int quantity)> items,
        CancellationToken ct = default);
}
