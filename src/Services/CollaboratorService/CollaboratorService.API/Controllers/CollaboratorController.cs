using CollaboratorService.Application.Commands.AddCollaborator;
using CollaboratorService.Application.DTOs;
using CollaboratorService.Application.Queries.GetCollaboratorsByNoteId;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using CollaboratorService.Application.Queries.GetCollaboratorsByNoteId;

namespace CollaboratorService.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CollaboratorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CollaboratorController(
            IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddCollaborator(
            AddCollaboratorRequest request)
        {
            var command =
                new AddCollaboratorCommand
                {
                    OwnerUserId = 1,
                    Request = request
                };

            var result =
                await _mediator.Send(command);

            return Ok(result);
        }


        [HttpGet("note/{noteId}")]
        public async Task<IActionResult> GetCollaboratorsByNoteId(long noteId)
        {
            var query = new GetCollaboratorsByNoteIdQuery
            {
                NoteId = noteId
            };

            var result = await _mediator.Send(query);

            return Ok(result);
        }
    }
}
