using System.Windows;
using VittaPayment.Client.ViewModels;

namespace VittaPayment.Client;

public partial class MainWindow : Window
{
    public MainWindow(MainViewModel mainViewModel)
    {
        InitializeComponent();
        DataContext = mainViewModel;
    }
}