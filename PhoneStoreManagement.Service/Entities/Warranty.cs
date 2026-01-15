using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhoneStoreManagement.Entity.Entities
{
    public class Warranty
    {
        [Key]
        public int WarrantyId { get; set; }

        public int InvoiceItemId { get; set; }
        [ForeignKey("InvoiceItemId")]
        public virtual InvoiceItem InvoiceItem { get; set; }

        // Thêm các trường này để tránh lỗi 'TEntity does not contain...'
        public string CustomerName { get; set; } 
        public string CustomerPhone { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        [NotMapped]
        public string Status => DateTime.Now <= EndDate ? "Còn hạn" : "Hết hạn";

    }
}