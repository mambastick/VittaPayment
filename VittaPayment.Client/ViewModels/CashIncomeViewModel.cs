using CommunityToolkit.Mvvm.ComponentModel;
using VittaPayment.Shared.Models;

namespace VittaPayment.Client.ViewModels;

public class CashIncomeViewModel(CashIncome cashIncome) : ObservableObject
{
    public int IncomeNumber
    {
        get => cashIncome.IncomeNumber;
        set => SetProperty(cashIncome.IncomeNumber, value, cashIncome, (ci, v) => ci.IncomeNumber = v);
    }

    public DateTime IncomeDate
    {
        get => cashIncome.IncomeDate;
        set => SetProperty(cashIncome.IncomeDate, value, cashIncome, (ci, v) => ci.IncomeDate = v);
    }

    public decimal Amount
    {
        get => cashIncome.Amount;
        set => SetProperty(cashIncome.Amount, value, cashIncome, (ci, v) => ci.Amount = v);
    }

    public decimal Balance
    {
        get => cashIncome.Balance;
        set => SetProperty(cashIncome.Balance, value, cashIncome, (ci, v) => ci.Balance = v);
    }
}