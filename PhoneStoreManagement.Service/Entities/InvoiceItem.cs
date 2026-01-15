using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneStoreManagement.Entity.Entities;

public class InvoiceItem
{
    public int InvoiceItemId { get; set; }
    public int InvoiceId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal LineTotal { get; set; }

    public Invoice? Invoice { get; set; }
    public Product? Product { get; set; }
    [NotMapped] // ✅ QUAN TRỌNG
    public string ProductName { get; set; } = "";
    public ICollection<Warranty> Warranties { get; set; } = new List<Warranty>();
}
