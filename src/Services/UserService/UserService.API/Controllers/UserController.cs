using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserService.Application.Authentication;
using UserService.Application.Commands.RegisterUser;
using UserService.Application.DTOs;


namespace UserService.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result)
            {
                return BadRequest("User already exists");
            }

            return Ok("User Registered Successfully");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var command = new LoginCommand(
                loginDto.Email,
                loginDto.Password
            );

            var result = await _mediator.Send(command);

            return Ok(result);
        }


        [Authorize]
        [HttpGet("test")]
        public IActionResult Test()
        {
            return Ok("JWT Authentication Working");
        }

    }
}
