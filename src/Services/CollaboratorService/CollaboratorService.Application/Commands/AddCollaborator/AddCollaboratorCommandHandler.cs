using CollaboratorService.Application.Interfaces;
using CollaboratorService.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollaboratorService.Application.Commands.AddCollaborator
{
    public class AddCollaboratorCommandHandler :
        IRequestHandler<AddCollaboratorCommand, string>
    {
        private readonly ICollaboratorRepository _repository;
        private readonly IUserServiceClient _userServiceClient;

        public AddCollaboratorCommandHandler(
            ICollaboratorRepository repository , IUserServiceClient userServiceClient)
        {
            _repository = repository;
            _userServiceClient = userServiceClient;
        }
        public async Task<string> Handle(AddCollaboratorCommand request,CancellationToken cancellationToken)
        {
            var user = await _userServiceClient
                .GetUserByEmailAsync(request.Request.Email);

            if (user == null)
            {
                throw new Exception("Collaborator user not found");
            }

            var collaborator = new Collaborator
            {
                NoteId = request.Request.NoteId,
                OwnerUserId = request.OwnerUserId,

                CollaboratorUserId = user.UserId,

                Permission = "VIEW",

                CreatedAt = DateTime.UtcNow
            };

            await _repository.AddCollaboratorAsync(collaborator);

            return "Collaborator added successfully";
        }
    }
}