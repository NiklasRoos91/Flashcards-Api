using Flashcards.Application.Features.AuthenticationFeature.DTOs;
using FluentValidation;

namespace Flashcards.Application.Features.AuthenticationFeature.Commands.LoginCommand
{
    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator(IValidator<LoginDto> loginDtoValidator)
        {
            RuleFor(x => x.LoginDto)
                .SetValidator(loginDtoValidator);
        }
    }
}
