using NajotBooking.Web.Brokers.Attributes;

namespace NajotBooking.Web.Models.Foundations.Seats
{
    public class Seat
    {
        public Guid Id { get; set; }

        [GreaterThanZero(ErrorMessage = "Number must be greater than 0")]
        public int Number { get; set; }
        public Branch Branch { get; set; }

        [GreaterThanZero(ErrorMessage = "Floor must be greater than 0")]
        public int Floor { get; set; }

        [GreaterThanZero(ErrorMessage = "Price must be greater than 0")]
        public decimal Price { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset UpdatedDate { get; set; }
    }
}
