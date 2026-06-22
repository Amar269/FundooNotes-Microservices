using CollaboratorService.Application.Commands.AddCollaborator;
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
    }
}
