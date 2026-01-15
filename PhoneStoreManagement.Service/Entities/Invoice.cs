    namespace PhoneStoreManagement.Entity.Entities
    {
        public class Invoice
        {
        public int InvoiceId { get; set; }
        public string InvoiceCode { get; set; } = "";
        public string InvoiceNo { get; set; } = null!;
        public string InvoiceType { get; set; } = null!;
        public int? SupplierId { get; set; }
        public int? CustomerId { get; set; }
        public DateTime InvoiceDate { get; set; } = DateTime.Now;
        public decimal TotalAmount { get; set; }
        public string Status { get; set; } = null!;
        public int EmployeeId { get; set; }
        public AppUser Employee { get; set; } = null!;
        public ICollection<InvoiceItem> InvoiceItems { get; set; } = new List<InvoiceItem>();
            public Supplier? Supplier { get; set; }
            public Customer? Customer { get; set; }
        }
    }
