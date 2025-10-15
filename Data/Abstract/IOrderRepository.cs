using Kokomija.Entity;

namespace Kokomija.Data.Abstract
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<Order?> GetOrderByOrderNumberAsync(string orderNumber);
        Task<Order?> GetOrderByStripePaymentIntentIdAsync(string paymentIntentId);
        Task<IEnumerable<Order>> GetOrdersByCustomerEmailAsync(string email);
        Task<IEnumerable<Order>> GetOrdersByStatusAsync(string status);
        Task<Order?> GetOrderWithItemsAsync(int id);
        Task<IEnumerable<Order>> GetRecentOrdersAsync(int count);
    }
}
