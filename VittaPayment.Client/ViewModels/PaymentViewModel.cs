using CommunityToolkit.Mvvm.ComponentModel;
using VittaPayment.Shared.Models;

namespace VittaPayment.Client.ViewModels;

public class PaymentViewModel(Payment payment) : ObservableObject
{
    public int PaymentId
    {
        get => payment.PaymentId;
        set => SetProperty(payment.PaymentId, value, payment, (p, v) => p.PaymentId = v);
    }

    public int OrderNumber
    {
        get => payment.OrderNumber;
        set => SetProperty(payment.OrderNumber, value, payment, (p, v) => p.OrderNumber = v);
    }

    public int IncomeNumber
    {
        get => payment.IncomeNumber;
        set => SetProperty(payment.IncomeNumber, value, payment, (p, v) => p.IncomeNumber = v);
    }

    public decimal PaymentAmount
    {
        get => payment.PaymentAmount;
        set => SetProperty(payment.PaymentAmount, value, payment, (p, v) => p.PaymentAmount = v);
    }
}