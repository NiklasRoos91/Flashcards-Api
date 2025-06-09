﻿using Flashcards.Api.Helpers;
using Flashcards.Application.Features.UserFeature.Commands.DeleteUser;
using Flashcards.Application.Features.UserFeature.DTOs;
using Flashcards.Application.Features.UserFeature.Queries.GetCurrentUser;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Flashcards.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("current")]
        [Authorize(Roles = "User")]
        public async Task<ActionResult<GetUserInfoDto>> GetCurrentUser(CancellationToken cancellationToken)
        {
            var userId = UserHelper.GetCurrentUserId(User);

            var query = new GetCurrentUserQuery(userId);

            var result = await _mediator.Send(query, cancellationToken);

            if (result.IsSuccess)
            {
                return Ok(result);
            }

            return NotFound(result);
        }

        [HttpDelete("current")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> DeleteCurrentUser(CancellationToken cancellationToken)
        {
            var userId = UserHelper.GetCurrentUserId(User);

            var command = new DeleteCurrentUserCommand(userId);

            var result = await _mediator.Send(command, cancellationToken);

            if (result.IsSuccess)
            {
                return NoContent();
            }

            return NotFound(result);
        }
    }
}
