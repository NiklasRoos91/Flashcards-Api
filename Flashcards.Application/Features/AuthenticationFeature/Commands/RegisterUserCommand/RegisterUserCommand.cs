using Flashcards.Application.Commons.OperationResult;
using Flashcards.Application.Features.AuthenticationFeature.DTOs;
using MediatR;

namespace Flashcards.Application.Features.AuthenticationFeature.Commands.RegisterUserCommand
{
    public class RegisterUserCommand : IRequest<OperationResult<RegisterUserResponseDto>>
    {
        public RegisterUserDto RegisterUserDto { get; set; } = null!;

        public RegisterUserCommand() {}
    }
}
