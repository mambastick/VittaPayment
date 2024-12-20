using VittaPayment.Shared.Models;

namespace VittaPayment.Services.Interfaces;

public interface IOrderService
{
    Task AddOrderAsync(Order order);
    Task<Order?> GetOrderAsync(int orderNumber);
    Task<IEnumerable<Order>> GetAllOrdersAsync();
    Task UpdateOrderAsync(Order order);
    Task DeleteOrderAsync(int orderNumber);
}