using Flashcards.Api.Helpers;
using Flashcards.Application.Features.UserFeature.DTOs;
using Flashcards.Application.Features.UserFeature.Queries.GetCurrentUserQuery;
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
                return Ok(result.Data);
            }

            return NotFound(result.ErrorMessage);
        }
    }
}
