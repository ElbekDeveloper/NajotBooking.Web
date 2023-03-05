using Microsoft.AspNetCore.Components;

namespace NajotBooking.Web.Pages.Seats
{
    public partial class DeleteSeat
    {
        [Parameter]
        public string SeatId { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var response = 
                await httpClient.DeleteAsync($"https://najot-booking.azurewebsites.net/api/Seats/{SeatId}");

            navigationManager.NavigateTo("/seats");
        }
    }
}
