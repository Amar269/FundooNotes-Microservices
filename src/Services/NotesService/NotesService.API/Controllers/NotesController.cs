using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NotesService.Application.Commands.CreateNote;
using NotesService.Application.Queries.GetAllNotes;
using System.Security.Claims;
using NotesService.Application.Queries.GetNoteById;

namespace NotesService.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class NotesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public NotesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateNote(
            CreateNoteCommand command)
        {
            var userIdClaim =  User.FindFirst(ClaimTypes.NameIdentifier);

            if (userIdClaim == null)
            {
                return Unauthorized();
            }

            command.UserId =
                Convert.ToInt64(userIdClaim.Value);

            var result =
                await _mediator.Send(command);

            return Ok(result);

        }


        [HttpGet]
        public async Task<IActionResult> GetAllNotes(long userId)
        {
            var query = new GetAllNotesQuery
            {
                UserId = userId
            };

            var result = await _mediator.Send(query);

            return Ok(result);
        }


        [HttpGet("{noteId}")]
        public async Task<IActionResult> GetNoteById(long noteId)
        {
            var query = new GetNoteByIdQuery
            {
                NoteId = noteId
            };

            var result = await _mediator.Send(query);

            if (result == null)
            {
                return NotFound("Note not found");
            }

            return Ok(result);
        }


    }
}
