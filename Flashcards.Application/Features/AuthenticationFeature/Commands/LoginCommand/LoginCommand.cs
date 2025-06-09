using Flashcards.Application.Commons.OperationResult;
using Flashcards.Application.Features.AuthenticationFeature.DTOs;
using MediatR;

namespace Flashcards.Application.Features.AuthenticationFeature.Commands.LoginCommand
{
    public class LoginCommand : IRequest<OperationResult<LoginUserResponseDto>>
    {
        public LoginDto LoginDto { get; set; } = null!;

        public LoginCommand(LoginDto loginDto)
        {
            LoginDto = loginDto ?? throw new ArgumentNullException(nameof(loginDto));
        }
    }
}
