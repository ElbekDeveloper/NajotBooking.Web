using NajotBooking.Web.Models.Foundations.Seats;

namespace NajotBooking.Web.Brokers.Apis
{
    public partial interface IApiBroker
    {
        ValueTask<Seat> PostSeatAsync(Seat seat);
    }
}
