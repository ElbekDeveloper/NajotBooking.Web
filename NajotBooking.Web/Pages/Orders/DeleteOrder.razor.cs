using Microsoft.AspNetCore.Components;
using NajotBooking.Web.Services.OrderServices;

namespace NajotBooking.Web.Pages.Orders
{
    public partial class DeleteOrder
    {
        [Inject]
        public IOrderService OrderService { get; set; }

        [Inject]
        public NavigationManager navManager { get; set; }

        [Parameter]
        public string orderId { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await OrderService.DeleteOrderById(Guid.Parse(orderId));
            navManager.NavigateTo("/AllOrders");
        }
    }
}
