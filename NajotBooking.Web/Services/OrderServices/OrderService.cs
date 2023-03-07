using Microsoft.AspNetCore.Components;
using NajotBooking.Web.Models.Foundations.Orders;

namespace NajotBooking.Web.Services.OrderServices
{
    public class OrderService : IOrderService
    {
        private readonly HttpClient httpClient;

        public OrderService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task PostOrder(Order order)
        {
            try
            {
                await httpClient.SendJsonAsync(
                    HttpMethod.Post, "api/Orders", order);
            }
            catch (Exception exception)
            { }
        }

        public async Task<IEnumerable<Order>> GetAllOrders()
        {
            try
            {
                return await httpClient
                    .GetJsonAsync<Order[]>("api/Orders");
            }
            catch (Exception exception)
            {
                return null;
            }
        }

        public async Task<Order> GetOrderById(Guid orderId)
        {
            try
            {
                return await httpClient
                    .GetJsonAsync<Order>($"api/Orders/{@orderId}");
            }
            catch (Exception exception)
            {
                return null;
            }
        }

        public async Task<Order> UpdateOrder(Order order)
        {
            try
            {
                return await httpClient.SendJsonAsync<Order>(
                    HttpMethod.Put, "api/Orders", order);
            }
            catch (Exception exception)
            {
                return null;
            }
        }

        public async Task DeleteOrderById(Guid orderId)
        {
            try
            {
                await httpClient.DeleteAsync(
                    $"api/Orders/{@orderId}");
            }
            catch (Exception exception)
            { }
        }

    }
}
