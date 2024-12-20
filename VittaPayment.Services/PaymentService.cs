using Dapper;
using Microsoft.Data.SqlClient;
using VittaPayment.Services.Interfaces;
using VittaPayment.Shared.Models;

namespace VittaPayment.Services;

public class PaymentService(string connectionString) : IPaymentService
{
    public async Task AddPaymentAsync(Payment payment)
    {
        await using var conn = new SqlConnection(connectionString);
        await conn.OpenAsync();
        const string sql = "INSERT INTO Payments (OrderNumber, IncomeNumber, PaymentAmount) VALUES (@OrderNumber, @IncomeNumber, @PaymentAmount)";
        await conn.ExecuteAsync(sql, payment);
    }

    public async Task<Payment?> GetPaymentAsync(int paymentId)
    {
        await using var conn = new SqlConnection(connectionString);
        await conn.OpenAsync();
        const string sql = "SELECT * FROM Payments WHERE PaymentId = @PaymentId";
        return await conn.QueryFirstOrDefaultAsync<Payment>(sql, new { PaymentId = paymentId });
    }

    public async Task<IEnumerable<Payment>> GetPaymentsByOrderAsync(int orderNumber)
    {
        await using var conn = new SqlConnection(connectionString);
        await conn.OpenAsync();
        const string sql = "SELECT * FROM Payments WHERE OrderNumber = @OrderNumber";
        return (await conn.QueryAsync<Payment>(sql, new { OrderNumber = orderNumber })).AsList();
    }

    public async Task UpdatePaymentAsync(Payment payment)
    {
        await using var conn = new SqlConnection(connectionString);
        await conn.OpenAsync();
        const string sql = "UPDATE Payments SET OrderNumber = @OrderNumber, IncomeNumber = @IncomeNumber, PaymentAmount = @PaymentAmount WHERE PaymentId = @PaymentId";
        await conn.ExecuteAsync(sql, payment);
    }

    public async Task DeletePaymentAsync(int paymentId)
    {
        await using var conn = new SqlConnection(connectionString);
        await conn.OpenAsync();
        const string sql = "DELETE FROM Payments WHERE PaymentId = @PaymentId";
        await conn.ExecuteAsync(sql, new { PaymentId = paymentId });
    }
}