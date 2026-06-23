using CollaboratorService.Application.Commands.AddCollaborator;
using CollaboratorService.Application.Commands.RemoveCollaborator;
using CollaboratorService.Application.Commands.UpdateCollaborator;
using CollaboratorService.Application.DTOs;
using CollaboratorService.Application.Queries.GetCollaboratorById;
using CollaboratorService.Application.Queries.GetCollaboratorById;
using CollaboratorService.Application.Queries.GetCollaboratorsByNoteId;
using CollaboratorService.Application.Queries.GetCollaboratorsByNoteId;
using CollaboratorService.Application.Queries.GetSharedNotes;
using CollaboratorService.Application.Commands.UpdateCollaborator;
using CollaboratorService.Application.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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


        [HttpGet("shared/{userId}")]
        public async Task<IActionResult> GetSharedNotes(long userId)
        {
            var result = await _mediator.Send(
                new GetSharedNotesQuery
                {
                    UserId = userId
                });

            return Ok(result);
        }


        [HttpGet("{collaboratorId}")]
        public async Task<IActionResult> GetCollaboratorById(long collaboratorId)
        {
            var result = await _mediator.Send(
                new GetCollaboratorByIdQuery
                {
                    CollaboratorId = collaboratorId
                });

            if (result == null)
            {
                return NotFound("Collaborator not found");
            }

            return Ok(result);
        }


        [HttpDelete("{collaboratorId}")]
        public async Task<IActionResult> RemoveCollaborator(long collaboratorId)
        {
            var result = await _mediator.Send(
                new RemoveCollaboratorCommand
                {
                    CollaboratorId = collaboratorId
                });

            return Ok(result);
        }

        [HttpPut("{collaboratorId}")]
        public async Task<IActionResult> UpdateCollaborator( long collaboratorId,
    [FromBody] UpdateCollaboratorDto request)
        {
            var result = await _mediator.Send(
                new UpdateCollaboratorCommand
                {
                    CollaboratorId = collaboratorId,
                    Request = request
                });

            return Ok(result);
        }
    }
}
