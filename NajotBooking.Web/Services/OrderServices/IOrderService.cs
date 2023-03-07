using NajotBooking.Web.Models.Foundations.Orders;

namespace NajotBooking.Web.Services.OrderServices
{
    public interface IOrderService
    {
        Task PostOrder(Order order);
        Task<IEnumerable<Order>> GetAllOrders();
        Task<Order> GetOrderById(Guid orderId);
        Task<Order> UpdateOrder(Order order);
        Task DeleteOrderById(Guid orderId);
    }
}
