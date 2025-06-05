using Flashcards.Application.Features.UserFeature.DTOs.Validators;
using FluentValidation;

namespace Flashcards.Application.Features.AuthenticationFeature.DTOs.Validators
{
    public class RegisterUserDtoValidator : AbstractValidator<RegisterUserDto>
    {
        public RegisterUserDtoValidator(UserInputBaseDtoValidator baseValidator)
        {
            Include(baseValidator);

            RuleFor(x => x.Username)
                .NotEmpty()
                .WithMessage("Username is required.")
                .Length(3, 50)
                .WithMessage("Username must be between 3 and 50 characters.");
        }
    }
}
