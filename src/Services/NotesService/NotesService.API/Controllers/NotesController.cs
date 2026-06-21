using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NotesService.Application.Commands.CreateNote;
using NotesService.Application.Queries.GetAllNotes;
using System.Security.Claims;
using NotesService.Application.Queries.GetNoteById;
using NotesService.Application.Commands.UpdateNote;
using NotesService.Application.Commands.DeleteNote;
using NotesService.Application.Commands.ArchiveNote;
using NotesService.Application.Commands.TrashNote;
using NotesService.Application.Commands.PinNote;
using NotesService.Application.Commands.ChangeColor;
using NotesService.Application.Commands.AddReminder;



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


        [HttpPut("{noteId}")]
        public async Task<IActionResult> UpdateNote(long noteId,UpdateNoteCommand command)
        {
            command.NoteId = noteId;

            var result = await _mediator.Send(command);

            if (result == null)
            {
                return NotFound("Note not found");
            }

            return Ok(result);
        }



        [HttpDelete("{noteId}")]
        public async Task<IActionResult> DeleteNote(long noteId)
        {
            var command = new DeleteNoteCommand
            {
                NoteId = noteId
            };

            var result = await _mediator.Send(command);

            if (!result)
            {
                return NotFound("Note not found");
            }

            return Ok("Note deleted successfully");
        }



        [HttpPatch("archive/{noteId}")]
        public async Task<IActionResult> ArchiveNote(long noteId)
        {
            var command = new ArchiveNoteCommand
            {
                NoteId = noteId
            };

            var result = await _mediator.Send(command);

            if (!result)
            {
                return NotFound("Note not found");
            }

            return Ok("Archive status updated successfully");
        }


        [HttpPatch("trash/{noteId}")]
        public async Task<IActionResult> TrashNote(long noteId)
        {
            var command = new TrashNoteCommand
            {
                NoteId = noteId
            };

            var result = await _mediator.Send(command);
            
            if (!result)
            {
                return NotFound("Note not found");
            }

            return Ok("Trash status updated successfully");
        }

        [HttpPatch("pin/{noteId}")]
        public async Task<IActionResult> PinNote(long noteId)
        {
            var command = new PinNoteCommand
            {
                NoteId = noteId
            };

            var result = await _mediator.Send(command);

            if (!result)
            {
                return NotFound("Note not found");
            }

            return Ok("Pin status updated successfully");
        }


        [HttpPatch("color/{noteId}")]
        public async Task<IActionResult> ChangeColor( long noteId,ChangeColorCommand command)
        {
            command.NoteId = noteId;

            var result = await _mediator.Send(command);

            if (!result)
            {
                return NotFound("Note not found");
            }

            return Ok("Color updated successfully");
        }

        [HttpPatch("reminder/{noteId}")]
        public async Task<IActionResult> AddReminder(long noteId,AddReminderCommand command)
        {
            command.NoteId = noteId;

            var result = await _mediator.Send(command);

            if (!result)
            {
                return NotFound("Note not found");
            }

            return Ok("Reminder added successfully");
        }
    }
}
