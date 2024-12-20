using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using VittaPayment.Services.Interfaces;
using VittaPayment.Shared.Models;

namespace VittaPayment.Client.ViewModels;

public class MainViewModel : ObservableObject
{
    private readonly IOrderService _orderService;
    private readonly ICashIncomeService _cashIncomeService;
    private readonly IPaymentService _paymentService;

    private Order _selectedOrder;
    private CashIncome _selectedCashIncome;
    private decimal _paymentAmount;

    public ObservableCollection<Order> Orders { get; } = new();
    public ObservableCollection<CashIncome> CashIncomes { get; } = new();
    public ObservableCollection<Payment> Payments { get; } = new();

    public MainViewModel(IOrderService orderService, ICashIncomeService cashIncomeService, IPaymentService paymentService)
    {
        _orderService = orderService;
        _cashIncomeService = cashIncomeService;
        _paymentService = paymentService;

        LoadDataCommand = new AsyncRelayCommand(LoadDataAsync);
        CreatePaymentCommand = new AsyncRelayCommand(CreatePaymentAsync, CanCreatePayment);

        LoadDataCommand.Execute(null);
    }

    public Order SelectedOrder
    {
        get => _selectedOrder;
        set
        {
            SetProperty(ref _selectedOrder, value);
            CreatePaymentCommand.NotifyCanExecuteChanged();
        }
    }

    public CashIncome SelectedCashIncome
    {
        get => _selectedCashIncome;
        set
        {
            SetProperty(ref _selectedCashIncome, value);
            CreatePaymentCommand.NotifyCanExecuteChanged();
        }
    }

    public decimal PaymentAmount
    {
        get => _paymentAmount;
        set
        {
            SetProperty(ref _paymentAmount, value);
            CreatePaymentCommand.NotifyCanExecuteChanged();
        }
    }

    public IAsyncRelayCommand LoadDataCommand { get; }
    public IAsyncRelayCommand CreatePaymentCommand { get; }

    private async Task LoadDataAsync()
    {
        var orders = await _orderService.GetAllOrdersAsync();
        Orders.Clear();
        foreach (var order in orders)
        {
            Orders.Add(order);
        }

        var cashIncomes = await _cashIncomeService.GetAllCashIncomesAsync();
        CashIncomes.Clear();
        foreach (var cashIncome in cashIncomes)
        {
            CashIncomes.Add(cashIncome);
        }
    }

    private async Task CreatePaymentAsync()
    {
        if (SelectedOrder == null || SelectedCashIncome == null || PaymentAmount <= 0)
            return;

        var payment = new Payment
        {
            OrderNumber = SelectedOrder.OrderNumber,
            IncomeNumber = SelectedCashIncome.IncomeNumber,
            PaymentAmount = PaymentAmount
        };

        await _paymentService.AddPaymentAsync(payment);
        await LoadDataAsync();
    }

    private bool CanCreatePayment()
    {
        return PaymentAmount > 0 && PaymentAmount <= SelectedCashIncome.Balance;
    }
}