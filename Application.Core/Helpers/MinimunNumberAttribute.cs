using System.ComponentModel.DataAnnotations;

namespace Application.Core.Helpers
{
    public class MinimunNumberAttribute: ValidationAttribute
    {
        public int Minimum { get; set; }
        public MinimunNumberAttribute(int minimum) 
        {
            Minimum = minimum;
        }

        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }

            int number = Convert.ToInt32(value);
            if (number < Minimum )
            {
                return new ValidationResult($"The minimum value must at least be {Minimum}.");
            }

            return ValidationResult.Success;
        }
    }
}
