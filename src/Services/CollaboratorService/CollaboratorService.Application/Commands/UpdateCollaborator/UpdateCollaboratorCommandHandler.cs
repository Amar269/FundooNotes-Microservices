using System;
using System.Collections.Generic;
using System.Text;
using CollaboratorService.Application.Interfaces;
using MediatR;

namespace CollaboratorService.Application.Commands.UpdateCollaborator
{
    public class UpdateCollaboratorCommandHandler
        : IRequestHandler<UpdateCollaboratorCommand, string>
    {
        private readonly ICollaboratorRepository _repository;

        public UpdateCollaboratorCommandHandler(
            ICollaboratorRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> Handle(
            UpdateCollaboratorCommand request,
            CancellationToken cancellationToken)
        {
            var collaborator =
                await _repository.GetCollaboratorByIdAsync(
                    request.CollaboratorId);

            if (collaborator == null)
            {
                throw new Exception("Collaborator not found");
            }

            collaborator.Permission =
                request.Request.Permission;

            await _repository.UpdateCollaboratorAsync(
                collaborator);

            return "Collaborator permission updated successfully";
        }
    }
}