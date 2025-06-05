using Flashcards.Application.Features.AuthenticationFeature.DTOs;
using FluentValidation;

namespace Flashcards.Application.Features.AuthenticationFeature.Commands.RegisterUserCommand
{
    public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator(IValidator<RegisterUserDto> registerUserDtoValidator)
        {
            RuleFor(x => x.RegisterUserDto)
                .SetValidator(registerUserDtoValidator);
        }
    }
}
