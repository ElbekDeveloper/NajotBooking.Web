using NajotBooking.Web.Models.Foundations.Seats;

namespace NajotBooking.Web.Brokers.Apis
{
    public partial class ApiBroker
    {
        public async ValueTask<Seat> PostSeatAsync(Seat seat) =>
            await PostAsync(relativeUrl: "/Seats", seat);
    }
}
