using FluentValidation;

namespace Flashcards.Application.Features.UserFeature.DTOs.Validators
{
    public class UserInputBaseDtoValidator : AbstractValidator<UserInputBaseDto>
    {
        public UserInputBaseDtoValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .WithMessage("First name is required.")
                .Length(2, 50)
                .WithMessage("First name must be between 2 and 50 characters.");

            RuleFor(x => x.LastName)
                .NotEmpty()
                .WithMessage("Last name is required.")
                .Length(2, 50)
                .WithMessage("Last name must be between 2 and 50 characters.");

            RuleFor(x => x.Address)
                .NotEmpty()
                .When(x => !string.IsNullOrWhiteSpace(x.Address))
                .WithMessage("Address must be between 5 and 100 characters.")
                .Length(5, 100)
                .When(x => !string.IsNullOrWhiteSpace(x.Address));

            RuleFor(x => x.PhoneNumber)
                .Matches(@"^\+?[0-9]{10,15}$")
                .When(x => !string.IsNullOrWhiteSpace(x.PhoneNumber))
                .WithMessage("Phone number must only contain digits and may start with '+'. No spaces or special characters are allowed. Example: +46701234567");

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email is required.")
                .EmailAddress()
                .WithMessage("Email must be a valid email address.");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Password is required.")
                .MinimumLength(8)
                .WithMessage("Password must be at least 8 characters long.")
                .Matches(@"[A-Z]")
                .WithMessage("Password must contain at least one uppercase letter.")
                .Matches(@"[a-z]")
                .WithMessage("Password must contain at least one lowercase letter.")
                .Matches(@"\d")
                .WithMessage("Password must contain at least one digit.")
                .Matches(@"[\!\?\*\.\@\#\$\%\^\&\+\=]")
                .WithMessage("Password must contain at least one special character (!?*.@#$%^&+=)");
        }
    }
}
