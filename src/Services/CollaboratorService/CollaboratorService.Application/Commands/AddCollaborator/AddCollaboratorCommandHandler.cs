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

        public AddCollaboratorCommandHandler(
            ICollaboratorRepository repository)
        {
            _repository = repository;
        }
        public async Task<string> Handle(
            AddCollaboratorCommand request,
            CancellationToken cancellationToken)
        {
            var collaborator = new Collaborator
            {
                NoteId = request.Request.NoteId,
                OwnerUserId = request.OwnerUserId,

                
                CollaboratorUserId = 1,

                Permission = "VIEW",

                CreatedAt = DateTime.UtcNow
            };

            await _repository.AddCollaboratorAsync(
                collaborator);

            return "Collaborator added successfully";
        }
    }
}