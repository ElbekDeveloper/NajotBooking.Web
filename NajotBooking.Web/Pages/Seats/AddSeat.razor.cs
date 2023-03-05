using NajotBooking.Web.Models.Foundations.Seats;
using Newtonsoft.Json;
using System.Text;

namespace NajotBooking.Web.Pages.Seats
{
    public partial class AddSeat
    {
        public bool isLoading = false;
        public Seat seat = new Seat();

        private async Task PostSeatAsync()
        {
            isLoading = true;
            DateTimeOffset now = DateTimeOffset.UtcNow;
            seat.Id = Guid.NewGuid();
            seat.CreatedDate = now;
            seat.UpdatedDate = now;

            var serializedSeat = JsonConvert.SerializeObject(seat);

            var requestContent =
                new StringContent(serializedSeat, Encoding.UTF8, "application/json");

            await httpClient.PostAsync("https://najot-booking.azurewebsites.net/api/Seats",
                    requestContent);

            navigationManager.NavigateTo("/seats");
            isLoading = false;
        }
    }
}
