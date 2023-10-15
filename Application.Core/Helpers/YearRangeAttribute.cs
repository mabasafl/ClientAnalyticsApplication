using System.ComponentModel.DataAnnotations;

namespace Application.Core.Helpers
{
    public class YearRangeAttribute : ValidationAttribute
    {
        public int MinimumYear { get; set; }
        public int MaximumYear { get; set; }
        public YearRangeAttribute(int minYear, int maxYear) 
        {
            MinimumYear = minYear;
            MaximumYear = maxYear;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }

            DateTime date = Convert.ToDateTime(value);
            if (date.Year < MinimumYear || date.Year > MaximumYear)
            {
                return new ValidationResult($"The date must be between {MinimumYear} and {MaximumYear}.");
            }

            return ValidationResult.Success;
        }
    }
}
