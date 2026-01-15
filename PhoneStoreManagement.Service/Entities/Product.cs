using System;
using System.Collections.Generic;

namespace PhoneStoreManagement.Entity.Entities;

public class Product
{
    public int ProductId { get; set; }

    // Mã sản phẩm: P000001
    public string ProductCode { get; set; } = null!;

    // IP 14 Pro Max
    public string ProductName { get; set; } = null!;

    // Apple
    public string Brand { get; set; } = null!;

    // Màu xanh 128GB, Màu titan 256GB...
    public string Variant { get; set; } = null!;

    // Việt Nam, Trung Quốc, Nhật Bản, Đức
    public string Origin { get; set; } = null!;

    // Giá nhập
    public decimal PurchasePrice { get; set; }

    // Giá bán
    public decimal SalePrice { get; set; }

    public DateTime CreatedDate { get; set; } = DateTime.Now;

    // Nhà cung cấp
    public int SupplierId { get; set; }
    //public string SupplierName { get; set; } = null!;
    public Supplier? Supplier { get; set; }

    // Liên kết hóa đơn
    // khai bao quantity
    public int Quantity { get; set; }
    public ICollection<InvoiceItem> InvoiceItems { get; set; } = new List<InvoiceItem>();
}
