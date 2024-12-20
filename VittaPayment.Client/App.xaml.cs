using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using VittaPayment.Services.Interfaces;
using VittaPayment.Client.ViewModels;
using VittaPayment.Services;

namespace VittaPayment.Client;

public partial class App : Application
{
    private readonly ServiceProvider _serviceProvider;

    public App()
    {
        var services = new ServiceCollection();
        ConfigureServices(services);
        _serviceProvider = services.BuildServiceProvider();
    }

    private void ConfigureServices(ServiceCollection services)
    {
        const string connectionString = "Server=tcp:localhostDatabase=VittaPayment;TrustServerCertificate=true;User Id=Vitta;Password=VP@ssw0rd23!;";

        // Регистрация сервисов
        services.AddTransient<ICashIncomeService>(_ => new CashIncomeService(connectionString));
        services.AddTransient<IOrderService>(_ => new OrderService(connectionString));
        services.AddTransient<IPaymentService>(_ => new PaymentService(connectionString));

        // Регистрация ViewModel
        services.AddTransient<MainViewModel>();

        // Регистрация главного окна
        services.AddSingleton<MainWindow>();
    }

    private void OnStartup(object sender, StartupEventArgs e)
    {
        var mainWindow = _serviceProvider.GetService<MainWindow>();
        mainWindow?.Show();
    }
}