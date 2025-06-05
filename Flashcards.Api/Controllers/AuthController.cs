using Flashcards.Application.Features.AuthenticationFeature.Commands.RegisterUserCommand;
using Flashcards.Application.Features.AuthenticationFeature.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Flashcards.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserCommand command)
        {
            if (command == null || command.RegisterUserDto == null)
            {
                return BadRequest("Invalid registration data.");
            }

            var result = await _mediator.Send(command);

            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.ErrorMessage);
        }
    }
}
