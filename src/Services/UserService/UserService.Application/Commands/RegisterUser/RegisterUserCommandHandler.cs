using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using UserService.Application.Interfaces;
using UserService.Domain.Entities;
using BCrypt.Net;

namespace UserService.Application.Commands.RegisterUser
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, bool>
    {

        private readonly IUserRepository _userRepository;
        private readonly IEmailService _emailService;

        public RegisterUserCommandHandler(IUserRepository userRepository, IEmailService emailService)
        {
            _userRepository = userRepository;
            _emailService = emailService;
        }

        public async Task<bool> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var existingUser =
                await _userRepository.GetUserByEmailAsync(request.Email);

            if (existingUser != null)
            {
                return false;
            }

            var user = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password)
            };

            await _userRepository.AddUserAsync(user);
            await _emailService.SendWelcomeEmailAsync(user.Email,user.FirstName);
            await _userRepository.SaveChangesAsync();

            return true;



            //throw new NotImplementedException();
        }

        


    }
}
