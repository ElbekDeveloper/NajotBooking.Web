using System.ComponentModel.DataAnnotations;
using NajotBooking.Web.Brokers.Attributes;
using NajotBooking.Web.Pages.Orders;

namespace NajotBooking.Web.Models.Foundations.Orders
{
    public class Order
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [InputSelectValidation]
        public Guid SeatId { get; set; }

        [Required]
        [InputSelectValidation]
        public Guid UserId { get; set; }

        [Required]
        [GreaterThanZero(ErrorMessage = "Price must be greater than 0")]
        public decimal Price { get; set; }

        [Required]
        public DateTimeOffset StartDate { get; set; } = DateTime.Now;

        [Required]
        public DateTimeOffset EndDate { get; set; } = DateTime.Now;

        [Required]
        public int Duration { get; set; }
    }
}
