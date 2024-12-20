using VittaPayment.Shared.Models;

namespace VittaPayment.Services.Interfaces;

public interface IPaymentService
{
    Task AddPaymentAsync(Payment payment);
    Task<Payment?> GetPaymentAsync(int paymentId);
    Task<IEnumerable<Payment>> GetPaymentsByOrderAsync(int orderNumber);
    Task UpdatePaymentAsync(Payment payment);
    Task DeletePaymentAsync(int paymentId);
}