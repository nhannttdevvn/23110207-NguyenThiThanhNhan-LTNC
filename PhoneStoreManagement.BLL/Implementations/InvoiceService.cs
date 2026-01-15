using Microsoft.EntityFrameworkCore;
using PhoneStoreManagement.Data;
using PhoneStoreManagement.Entity.Entities;
using PhoneStoreManagement.Services.Interfaces;

namespace PhoneStoreManagement.Services.Implementations;

public class InvoiceService : IInvoiceService
{
    private readonly PhoneDbContext _db;

    public InvoiceService(PhoneDbContext db)
    {
        _db = db;
    }

    public async Task CreateOrderAsync(
        string customerName,
        string phone,
        string address,
        int employeeId,
        List<(int productId, int quantity)> items,
        CancellationToken ct = default)
    {
        using var tran = await _db.Database.BeginTransactionAsync(ct);

        try
        {
            // 1. CUSTOMER
            var customer = await _db.Customers
                .FirstOrDefaultAsync(x => x.Phone == phone, ct);

            if (customer == null)
            {
                customer = new Customer
                {
                    FullName = customerName,
                    Phone = phone,
                    Address = address
                };
                _db.Customers.Add(customer);
                await _db.SaveChangesAsync(ct);
            }

            // 2. INVOICE
            var invoice = new Invoice
            {
                InvoiceNo = $"HD{DateTime.Now:yyyyMMddHHmmss}",
                InvoiceType = "Sale",
                InvoiceDate = DateTime.Now,
                CustomerId = customer.CustomerId,
                EmployeeId = employeeId,   // ✅ QUAN TRỌNG
                TotalAmount = 0,
                Status = "Completed"
            };

            _db.Invoices.Add(invoice);
            await _db.SaveChangesAsync(ct);

            decimal total = 0;

            // 3. ITEMS + TRỪ KHO
            foreach (var (productId, quantity) in items)
            {
                var product = await _db.Products
                    .FirstAsync(x => x.ProductId == productId, ct);

                if (product.Quantity < quantity)
                    throw new Exception($"Sản phẩm {product.ProductName} không đủ tồn kho");

                product.Quantity -= quantity;

                var item = new InvoiceItem
                {
                    InvoiceId = invoice.InvoiceId,
                    ProductId = productId,
                    Quantity = quantity,
                    UnitPrice = product.SalePrice,
                    LineTotal = quantity * product.SalePrice
                };

                total += item.LineTotal;
                _db.InvoiceItems.Add(item);
            }

            invoice.TotalAmount = total;

            await _db.SaveChangesAsync(ct);
            await tran.CommitAsync(ct);
        }
        catch
        {
            await tran.RollbackAsync(ct);
            throw;
        }
    }
}
