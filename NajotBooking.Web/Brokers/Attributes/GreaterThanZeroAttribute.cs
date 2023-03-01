using System.ComponentModel.DataAnnotations;

namespace NajotBooking.Web.Brokers.Attributes
{
    public class GreaterThanZeroAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object value, ValidationContext validationContext)
        {
            if(value is int intValue && intValue > 0)
            {
                return ValidationResult.Success;
            }

            else if (value is decimal decimalValue && decimalValue > 0)
            {
                return ValidationResult.Success;
            }
            else
            {
               return new ValidationResult(ErrorMessage);
            }
        }
    }
}
