using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneStoreManagement.Entity.Entities
{
    public class Supplier
    {
        public int SupplierId { get; set; }
        public string SupplierName { get; set; } = "";
        public string Phone { get; set; } = "";
        public string Address { get; set; } = "";
        public string Email { get; set; } = "";
        public string? Note { get; set; }

        public ICollection<Product> Products { get; set; } = new List<Product>();
        public ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
    }
}
