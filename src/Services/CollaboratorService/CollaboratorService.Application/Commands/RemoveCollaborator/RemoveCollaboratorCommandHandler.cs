using System;
using System.Collections.Generic;
using System.Text;
using CollaboratorService.Application.Interfaces;
using MediatR;

namespace CollaboratorService.Application.Commands.RemoveCollaborator
{
    public class RemoveCollaboratorCommandHandler
        : IRequestHandler<RemoveCollaboratorCommand, string>
    {
        private readonly ICollaboratorRepository _repository;

        public RemoveCollaboratorCommandHandler(
            ICollaboratorRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> Handle(
            RemoveCollaboratorCommand request,
            CancellationToken cancellationToken)
        {
            var collaborator =
                await _repository.GetCollaboratorByIdAsync(
                    request.CollaboratorId);

            if (collaborator == null)
            {
                throw new Exception("Collaborator not found");
            }

            await _repository.RemoveCollaboratorAsync(collaborator);

            return "Collaborator removed successfully";
        }
    }
}