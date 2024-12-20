namespace VittaPayment.Shared.Models;

public class Order
{
    public int OrderNumber { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal TotalAmount { get; set; }
    public decimal PaymentAmount { get; set; }
}
