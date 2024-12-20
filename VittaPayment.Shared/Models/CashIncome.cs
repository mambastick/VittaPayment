namespace VittaPayment.Shared.Models;

public class CashIncome
{
    public int IncomeNumber { get; set; }
    public DateTime IncomeDate { get; set; }
    public decimal Amount { get; set; }
    public decimal Balance { get; set; }
}
