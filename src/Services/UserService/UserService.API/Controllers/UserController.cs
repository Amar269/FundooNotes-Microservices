using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedLibrary.Exceptions.Exceptions;
using UserService.Application.Authentication;
using UserService.Application.Commands.RegisterUser;
using UserService.Application.DTOs;
using UserService.Application.Queries.GetUserByEmail;


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


        [HttpGet("exception-test")]
        public IActionResult ExceptionTest()
        {
            //throw new Exception("Testing Global Exception Middleware");
            throw new NotFoundException("User Not Found");
        }


        [HttpGet("email/{email}")]
        public async Task<IActionResult> GetUserByEmail(string email)
        {
            var result = await _mediator.Send(
                new GetUserByEmailQuery(email));

            return Ok(result);
        }
    }
}
