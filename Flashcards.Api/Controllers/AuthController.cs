﻿using Flashcards.Application.Features.AuthenticationFeature.Commands.Login;
using Flashcards.Application.Features.AuthenticationFeature.Commands.RegisterUser;
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
        public async Task<ActionResult<RegisterUserResponseDto>> Register([FromBody] RegisterUserCommand command, CancellationToken cancellationToken)
        {
            if (command == null || command.RegisterUserDto == null)
            {
                return BadRequest("Invalid registration data.");
            }

            var result = await _mediator.Send(command, cancellationToken);

            if (result.IsSuccess)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginUserResponseDto>> Login([FromBody] LoginCommand command, CancellationToken cancellationToken)
        {
            if (command == null || command.LoginDto == null)
            {
                return BadRequest("Invalid login data.");
            }
            var result = await _mediator.Send(command, cancellationToken);

            if (result.IsSuccess)
            {
                return Ok(result);
            }

            return Unauthorized(result);
        }
    }
}
