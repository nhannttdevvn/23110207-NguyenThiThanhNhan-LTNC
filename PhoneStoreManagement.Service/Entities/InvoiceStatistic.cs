namespace PhoneStoreManagement.Domain.Entities;

public class InvoiceStatistic
{
    public int InvoiceId { get; set; }
    public string CustomerName { get; set; } = "";
    public string CustomerAddress { get; set; } = "";
    public DateTime InvoiceDate { get; set; }
    public decimal TotalAmount { get; set; }
}
