using System.ComponentModel.DataAnnotations;

namespace Task1.Validation;

public class NotInFutureAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext context)
    {
        if (value is DateTime date && date > DateTime.Now)
        {
            return new ValidationResult(ErrorMessage ?? "Date cannot be in the future.");
        }

        return ValidationResult.Success;
    }
}