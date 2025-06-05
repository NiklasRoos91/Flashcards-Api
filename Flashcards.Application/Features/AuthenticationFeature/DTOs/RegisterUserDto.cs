using Flashcards.Application.Features.UserFeature.DTOs;

namespace Flashcards.Application.Features.AuthenticationFeature.DTOs
{
    public class RegisterUserDto : UserInputBaseDto
    {
        public string Username { get; set; } = null!;
    }
}
