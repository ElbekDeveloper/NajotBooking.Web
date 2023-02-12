namespace NajotBooking.Web.Models.Foundations.Seats
{
    public class Seat
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public Branch Branch { get; set; }
        public int Floor { get; set; }
        public decimal Price { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset UpdatedDate { get; set; }
    }
}
