using Flashcards.Application.Commons.OperationResult;
using Flashcards.Application.Features.FlashcardsFeature.DTOs.Requests;
using Flashcards.Application.Features.FlashcardsFeature.DTOs.Responses;
using MediatR;

namespace Flashcards.Application.Features.FlashcardsFeature.Commands.CreateFlashcardList
{
    public class CreateFlashcardList : IRequest<OperationResult<CreateFlashcardListResponseDto>>
    {
        public CreateFlashcardListDto CreateFlashcardListDto { get; set; } = null!;
        public Guid UserId { get; set; }

        public CreateFlashcardList(CreateFlashcardListDto createFlashcardListDto, Guid userId)
        {
            CreateFlashcardListDto = createFlashcardListDto ?? throw new ArgumentNullException(nameof(createFlashcardListDto));
            UserId = userId;
        }
    }
}
