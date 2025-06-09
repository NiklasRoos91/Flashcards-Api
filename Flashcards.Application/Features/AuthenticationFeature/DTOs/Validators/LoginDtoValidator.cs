using FluentValidation;

namespace Flashcards.Application.Features.AuthenticationFeature.DTOs.Validators
{
    public class LoginDtoValidator : AbstractValidator<LoginDto>
    {
        public LoginDtoValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email  is required.")
                .EmailAddress().WithMessage("Email must be valid.");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Password is required.");
        }
    }
}
