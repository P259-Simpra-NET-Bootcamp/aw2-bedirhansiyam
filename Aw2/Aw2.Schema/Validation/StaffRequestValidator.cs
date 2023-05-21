using FluentValidation;
using System.Text.RegularExpressions;

namespace Aw2.Schema.Validation;

public class StaffRequestValidator : AbstractValidator<StaffRequest>
{
    public StaffRequestValidator()
    {
        RuleFor(c => c.FirstName)
            .NotEmpty().WithMessage("First name is required.")
            .NotNull().WithMessage("First name is required.")
            .MinimumLength(3).WithMessage("First name must not be less than 3 characters.")
            .MaximumLength(30).WithMessage("First name must not exceed 30 characters.");

        RuleFor(c => c.LastName)
            .NotEmpty().WithMessage("Last name is required.")
            .NotNull().WithMessage("Last name is required.")
            .MinimumLength(3).WithMessage("Last name must not be less than 3 characters.")
            .MaximumLength(30).WithMessage("Last name must not exceed 30 characters.");

        RuleFor(c => c.Email)
            .NotEmpty().WithMessage("Email is required.")
            .NotNull().WithMessage("Email is required.")
            .MinimumLength(10).WithMessage("Email must not be less than 10 characters.")
            .MaximumLength(30).WithMessage("Email must not exceed 30 characters.")
            .EmailAddress().WithMessage("Email not valid");

        RuleFor(c => c.Phone)
            .NotEmpty().WithMessage("Phone number is required.")
            .NotNull().WithMessage("Phone number is required.")
            .Length(11).WithMessage("Phone number must be 11 characters")
            .Matches(new Regex("\\d{11}")).WithMessage("Phone number not valid");

        RuleFor(c => c.DateOfBirth)
            .LessThan(p => DateTime.Now.Date).WithMessage("Date of birth must not be today.");

        RuleFor(c => c.AddressLine1)
            .MinimumLength(7).WithMessage("Address must not be less than 7 characters.")
            .MaximumLength(150).WithMessage("Address must not exceed 150 characters.");

        RuleFor(c => c.City)
            .MinimumLength(2).WithMessage("City must not be less than 2 characters.")
            .MaximumLength(20).WithMessage("City must not exceed 20 characters.");

        RuleFor(c => c.Country)
            .MinimumLength(3).WithMessage("Country must not be less than 3 characters.")
            .MaximumLength(20).WithMessage("Country must not exceed 20 characters.");

        RuleFor(c => c.Province)
            .MinimumLength(3).WithMessage("Province must not be less than 3 characters.")
            .MaximumLength(20).WithMessage("Province must not exceed 20 characters.");
    }
}
