using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneStoreManagement.Entity.Entities;

public class Customer
{
    public int CustomerId { get; set; }

    public string FullName { get; set; } = "";
    public string Phone { get; set; } = "";
    public string Address { get; set; } = "";
    public string Email { get; set; } = "";

    public ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
    public ICollection<Warranty> Warranties { get; set; } = new List<Warranty>();
}
