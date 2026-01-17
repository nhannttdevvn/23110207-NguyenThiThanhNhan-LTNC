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

    // Thay đổi kiểu trả về từ Task thành Task<int>
    public async Task<int> CreateOrderAsync(
        string customerName,
        string phone,
        string address,
        int employeeId,
        List<(int productId, int quantity)> items,
        CancellationToken ct = default)
    {   // mở phiên tạm thời, lúc này chưa ghi vào DB : tạo hóa đơn, trừ kho, tạo bảo hành cùng lúc 
        using var tran = await _db.Database.BeginTransactionAsync(ct);

        try
        {
            // 1. XỬ LÝ KHÁCH HÀNG
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

            // 2. TẠO HÓA ĐƠN (INVOICE)
            var invoice = new Invoice
            {
                InvoiceNo = $"HD{DateTime.Now:yyyyMMddHHmmss}",
                InvoiceType = "Sale",
                InvoiceDate = DateTime.Now,
                CustomerId = customer.CustomerId,
                EmployeeId = employeeId,
                TotalAmount = 0,
                Status = "Completed"
            };

            _db.Invoices.Add(invoice);
            await _db.SaveChangesAsync(ct); // Lưu để lấy InvoiceId tự sinh từ DB

            decimal total = 0;

            // 3. XỬ LÝ TỪNG SẢN PHẨM + TẠO BẢO HÀNH
            foreach (var (productId, quantity) in items)
            {
                var product = await _db.Products
                    .FirstAsync(x => x.ProductId == productId, ct);

                if (product.Quantity < quantity)
                    throw new Exception($"Sản phẩm {product.ProductName} không đủ tồn kho");

                // Trừ kho
                product.Quantity -= quantity;

                // Tạo chi tiết hóa đơn
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

                // Lưu để lấy được InvoiceItemId cho bảng Warranty
                await _db.SaveChangesAsync(ct);

                // TỰ ĐỘNG TẠO BẢO HÀNH
                var warranty = new Warranty
                {
                    InvoiceItemId = item.InvoiceItemId,
                    CustomerName = customerName,
                    CustomerPhone = phone,
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddMonths(12)
                };
                _db.Warranties.Add(warranty);
            }

            // Cập nhật tổng tiền cuối cùng của hóa đơn
            invoice.TotalAmount = total;

            await _db.SaveChangesAsync(ct);
            await tran.CommitAsync(ct);

            // ✅ TRẢ VỀ ID CỦA HÓA ĐƠN VỪA TẠO
            return invoice.InvoiceId;
        }
        catch
        {
            await tran.RollbackAsync(ct);
            throw;
        }
    }
}