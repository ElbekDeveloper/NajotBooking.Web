using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using NajotBooking.Web.Models.Foundations.Orders;
using NajotBooking.Web.Services.OrderServices;

namespace NajotBooking.Web.Pages.Orders
{
    public partial class AllOrders
    {
        [Inject]
        public IOrderService OrderService { get; set; }

        [Inject]
        public IJSRuntime JsRuntime { get; set; }
        public IEnumerable<Order> Orders { get; set; }

        private int orderNumber = 1;

        protected override async Task OnInitializedAsync()
        {
            Orders = (await OrderService.GetAllOrders()).ToList();
        }
        public async Task DeleteOrderById(Guid orderId)
        {
            await OrderService.DeleteOrderById(orderId);

            Orders = (await OrderService.GetAllOrders()).ToList();
            StateHasChanged();
        }

        public async void ConfirmDelelte(Guid orderId)
        {
            bool IsConfirmed = await JsRuntime.InvokeAsync<bool>("confirm", "Do you want do Delelte Order");

            if (IsConfirmed)
            {
                DeleteOrderById(orderId);
            }
        }
    }
}
