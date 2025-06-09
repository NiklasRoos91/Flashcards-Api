using Flashcards.Api.Helpers;
using Flashcards.Application.Commons.OperationResult;
using Flashcards.Application.Features.FlashcardsFeature.Commands.CreateFlashcardList;
using Flashcards.Application.Features.FlashcardsFeature.DTOs.Requests;
using Flashcards.Application.Features.FlashcardsFeature.DTOs.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Flashcards.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlashcardsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FlashcardsController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost("create-flashcard-list")]
        public async Task<ActionResult<CreateFlashcardListResponseDto>> CreateFlashcardList([FromBody] CreateFlashcardListDto dto, CancellationToken cancellationToken)
        {
            var userId = UserHelper.GetCurrentUserId(User);

            var command = new CreateFlashcardList(dto, userId);

            var result = await _mediator.Send(command);

            if (result.IsSuccess)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
