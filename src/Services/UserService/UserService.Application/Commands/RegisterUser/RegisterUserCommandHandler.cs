using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using UserService.Application.Interfaces;
using UserService.Domain.Entities;
using BCrypt.Net;
using SharedLibrary.Messaging.Interfaces;
using SharedLibrary.Contracts.Events;

namespace UserService.Application.Commands.RegisterUser
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, bool>
    {

        private readonly IUserRepository _userRepository;
        private readonly IEmailService _emailService;
        private readonly IRabbitMqPublisher _rabbitMqPublisher;

        public RegisterUserCommandHandler(IUserRepository userRepository, IEmailService emailService , IRabbitMqPublisher rabbitMqPublisher)
        {
            _userRepository = userRepository;
            _emailService = emailService;
            _rabbitMqPublisher = rabbitMqPublisher;
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

            var userRegisteredEvent = new UserRegisteredEvent
            {
                UserId = user.UserId,
                FullName = $"{user.FirstName} {user.LastName}",
                Email = user.Email
            };
            await _rabbitMqPublisher.PublishAsync("user_registered_queue",userRegisteredEvent);


            return true;



            //throw new NotImplementedException();
        }

        


    }
}
