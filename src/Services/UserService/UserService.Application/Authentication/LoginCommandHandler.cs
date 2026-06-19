using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using BCrypt.Net;
using MediatR;
using UserService.Application.DTOs;
using UserService.Application.Interfaces;

namespace UserService.Application.Authentication
{
    public  class LoginCommandHandler : IRequestHandler<LoginCommand , AuthResponseDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtService _jwtService;


        public LoginCommandHandler(
            IUserRepository userRepository,
            IJwtService jwtService)
        {
            _userRepository = userRepository;
            _jwtService = jwtService;
        }

        public async Task<AuthResponseDto> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByEmailAsync(request.Email);

            if (user == null)
            {
                throw new Exception("Invalid Email or Password");
            }

            bool isPasswordValid =BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash);
            if (!isPasswordValid)
            {
                throw new Exception("Invalid Email or Password");
            }

            var token = _jwtService.GenerateToken(user);
            return new AuthResponseDto(token,user.Email,$"{user.FirstName} {user.LastName}");


        }
    }
}
