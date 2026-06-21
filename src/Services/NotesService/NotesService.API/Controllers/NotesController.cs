using MediatR;
using Microsoft.AspNetCore.Mvc;
using NotesService.Application.Commands.CreateNote;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

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
    }
}
