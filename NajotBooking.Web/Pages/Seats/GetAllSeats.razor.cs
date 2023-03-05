using NajotBooking.Web.Models.Foundations.Seats;

namespace NajotBooking.Web.Pages.Seats
{
    public partial class GetAllSeats
    {
        public int order = 1;
        public IEnumerable<Seat> RetrieveAllSeats = new List<Seat>();

        protected override async Task OnInitializedAsync()
        {
            var response =
                await httpClient.GetAsync("https://najot-booking.azurewebsites.net/api/Seats");

            RetrieveAllSeats =
                await response.Content.ReadFromJsonAsync<IEnumerable<Seat>>();
        }
    }
}
