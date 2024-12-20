using CommunityToolkit.Mvvm.ComponentModel;
using VittaPayment.Shared.Models;

namespace VittaPayment.Client.ViewModels;

public class OrderViewModel(Order order) : ObservableObject
{
    public int OrderNumber
    {
        get => order.OrderNumber;
        set => SetProperty(order.OrderNumber, value, order, (o, v) => o.OrderNumber = v);
    }

    public DateTime OrderDate
    {
        get => order.OrderDate;
        set => SetProperty(order.OrderDate, value, order, (o, v) => o.OrderDate = v);
    }

    public decimal TotalAmount
    {
        get => order.TotalAmount;
        set => SetProperty(order.TotalAmount, value, order, (o, v) => o.TotalAmount = v);
    }

    public decimal PaymentAmount
    {
        get => order.PaymentAmount;
        set => SetProperty(order.PaymentAmount, value, order, (o, v) => o.PaymentAmount = v);
    }
}