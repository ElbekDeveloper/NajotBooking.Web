using System.ComponentModel.DataAnnotations;

namespace NajotBooking.Web.Pages.Orders
{
    public class InputSelectValidation : ValidationAttribute
    {

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            Guid guid = Guid.Empty;

            if (guid.CompareTo(value) == 0)
            {
                return new ValidationResult("Select value");
            }

            return null;
        }
    }
}
