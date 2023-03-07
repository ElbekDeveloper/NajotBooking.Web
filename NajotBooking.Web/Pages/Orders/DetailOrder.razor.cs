using Microsoft.AspNetCore.Components;
using NajotBooking.Web.Models.Foundations.Orders;
using NajotBooking.Web.Models.Foundations.Seats;
using NajotBooking.Web.Models.Foundations.Users;
using NajotBooking.Web.Services.OrderServices;
using NajotBooking.Web.Services.UserServices;

namespace NajotBooking.Web.Pages.Orders
{
    public partial class DetailOrder
    {
        [Parameter]
        public string orderId { get; set; }

        [Inject]
        public HttpClient httpClient { get; set; }

        [Inject]
        public NavigationManager NavManager { get; set; }

        [Inject]
        public IOrderService OrderService { get; set; }

        [Inject]
        public IUserService UserService { get; set; }
        public IEnumerable<Seat> AllSeats { get; set; }
        public IEnumerable<User> AllUsers { get; set; }
        public Order order;
        protected override async Task OnInitializedAsync()
        {
            order = (await OrderService.GetOrderById(Guid.Parse(orderId)));
            AllUsers = (await UserService.GetAllUsers()).ToList();
            await LoadSeatsAsync();
        }
        public async Task UpdateOrder()
        {
            order.Duration = GetDuration();
            await OrderService.UpdateOrder(order);
            NavManager.NavigateTo("/AllOrders");
        }

        public async Task LoadSeatsAsync()
        {
            httpClient = new HttpClient();
            AllSeats = await httpClient.GetJsonAsync<Seat[]>
                ("https://najot-booking.azurewebsites.net/api/Seats");
        }

        public int GetDuration()
        {
            int duration = 0;
            TimeSpan timeSpan;
            timeSpan = order.EndDate.Subtract(order.StartDate);
            duration = (int)Math.Ceiling(timeSpan.TotalHours);

            return duration;
        }
    }
}
