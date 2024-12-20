using Dapper;
using Microsoft.Data.SqlClient;
using VittaPayment.Services.Interfaces;
using VittaPayment.Shared.Models;

namespace VittaPayment.Services;

public class OrderService(string connectionString) : IOrderService
{
    public async Task AddOrderAsync(Order order)
    {
        await using var conn = new SqlConnection(connectionString);
        await conn.OpenAsync();
        const string sql = "INSERT INTO Orders (OrderNumber, OrderDate, TotalAmount) VALUES (@OrderNumber, @OrderDate, @TotalAmount)";
        await conn.ExecuteAsync(sql, order);
    }

    public async Task<Order?> GetOrderAsync(int orderNumber)
    {
        await using var conn = new SqlConnection(connectionString);
        await conn.OpenAsync();
        const string sql = "SELECT * FROM Orders WHERE OrderNumber = @OrderNumber";
        return await conn.QueryFirstOrDefaultAsync<Order>(sql, new { OrderNumber = orderNumber });
    }

    public async Task<IEnumerable<Order>> GetAllOrdersAsync()
    {
        await using var conn = new SqlConnection(connectionString);
        await conn.OpenAsync();
        const string sql = "SELECT * FROM Orders";
        return (await conn.QueryAsync<Order>(sql)).AsList();
    }

    public async Task UpdateOrderAsync(Order order)
    {
        await using var conn = new SqlConnection(connectionString);
        await conn.OpenAsync();
        const string sql = "UPDATE Orders SET OrderDate = @OrderDate, TotalAmount = @TotalAmount, PaymentAmount = @PaymentAmount WHERE OrderNumber = @OrderNumber";
        await conn.ExecuteAsync(sql, order);
    }

    public async Task DeleteOrderAsync(int orderNumber)
    {
        await using var conn = new SqlConnection(connectionString);
        await conn.OpenAsync();
        const string sql = "DELETE FROM Orders WHERE OrderNumber = @OrderNumber";
        await conn.ExecuteAsync(sql, new { OrderNumber = orderNumber });
    }
}