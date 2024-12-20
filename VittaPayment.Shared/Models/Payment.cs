namespace VittaPayment.Shared.Models;

public class Payment
{
    public int PaymentId { get; set; }
    public int OrderNumber { get; set; }
    public int IncomeNumber { get; set; }
    public decimal PaymentAmount { get; set; }
}
