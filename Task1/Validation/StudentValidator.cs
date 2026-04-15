using FluentValidation;
using Task1.DTOs.Student;

namespace Task1.Validation
{
    public class StudentValidator : AbstractValidator<StudentRequest>
    {
        public StudentValidator()
        {
            RuleFor(s => s.FullName).NotEmpty().WithMessage("Full name is required").MinimumLength(3).WithMessage("min 3").MaximumLength(100).WithMessage("max 100");
            RuleFor(s => s.Email).NotEmpty().WithMessage("Email is required").EmailAddress().MaximumLength(100).WithMessage("max 100");
            RuleFor(s => s.Age).NotEmpty().WithMessage("Age required").LessThanOrEqualTo(60).GreaterThanOrEqualTo(18);
            RuleFor(s => s.StudentGender).NotEmpty().IsInEnum();
            RuleFor(s => s.PhoneNumber).NotEmpty().MinimumLength(10).MaximumLength(15);
            RuleFor(s => s.Address).MaximumLength(200);
            RuleFor(s => s.Department).NotEmpty().MaximumLength(100);
            RuleFor(s => s.EnrollmentDate).LessThanOrEqualTo(DateTime.UtcNow)
                .WithMessage("Enrollment date cannot be in the future");
        }
    }
}