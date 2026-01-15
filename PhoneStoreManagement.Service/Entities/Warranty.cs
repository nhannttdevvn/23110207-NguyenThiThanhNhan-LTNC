using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneStoreManagement.Entity.Entities;

public class Warranty
{
    public int WarrantyId { get; set; }
    public string WarrantyNo { get; set; } = "";

    public int InvoiceItemId { get; set; }
    public int ProductId { get; set; }
    public int CustomerId { get; set; }

    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public string Status { get; set; } = "Active";
    public string? Note { get; set; }

    public InvoiceItem? InvoiceItem { get; set; }
    public Product? Product { get; set; }
    public Customer? Customer { get; set; }
}
