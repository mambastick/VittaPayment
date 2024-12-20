using VittaPayment.Shared.Models;

namespace VittaPayment.Services.Interfaces;

public interface ICashIncomeService
{
    Task AddCashIncomeAsync(CashIncome cashIncome);
    Task<CashIncome?> GetCashIncomeAsync(int incomeNumber);
    Task<IEnumerable<CashIncome>> GetAllCashIncomesAsync();
    Task UpdateCashIncomeAsync(CashIncome cashIncome);
    Task DeleteCashIncomeAsync(int incomeNumber);
}