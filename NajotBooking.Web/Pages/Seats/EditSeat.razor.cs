using Microsoft.AspNetCore.Components;
using NajotBooking.Web.Models.Foundations.Seats;
using Newtonsoft.Json;
using System.Text;

namespace NajotBooking.Web.Pages.Seats
{
    public partial class EditSeat
    {
        [Parameter]
        public string seatId { get; set; }

        public bool isLoading = false;

        private Seat seat = new Seat();

        protected override async Task OnInitializedAsync()
        {
            try
            {
                var uri = new Uri(navigationManager.Uri);
                seatId = uri.Segments.LastOrDefault();

                var response =
                    await httpClient.GetAsync($"https://najot-booking.azurewebsites.net/api/Seats/{seatId}");

                if (response.IsSuccessStatusCode)
                {
                    seat = await response.Content.ReadFromJsonAsync<Seat>();
                }
            }
            catch (Exception)
            {
                navigationManager.NavigateTo("/error");
            }
        }

        private async Task EditSeatAsync()
        {
            try
            {
                isLoading = true;
                seat.UpdatedDate = DateTimeOffset.UtcNow;
                var serializedSeat = JsonConvert.SerializeObject(seat);

                var requestContent =
                    new StringContent(serializedSeat, Encoding.UTF8, "application/json");

                var response =
                    await httpClient.PutAsync("https://najot-booking.azurewebsites.net/api/Seats",
                        requestContent);

                if (response.IsSuccessStatusCode)
                {
                    navigationManager.NavigateTo("/seats");
                }
                else
                {
                    navigationManager.NavigateTo($"https://najot-booking.azurewebsites.net/api/Seats/{seatId}");
                }

                isLoading = false;
            }
            catch (Exception)
            {
                navigationManager.NavigateTo("/error");
            }
        }
    }
}
