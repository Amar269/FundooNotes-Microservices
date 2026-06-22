using System;
using System.Collections.Generic;
using System.Text;
using CollaboratorService.Application.Interfaces;
using CollaboratorService.Domain.Entities;
using MediatR;

namespace CollaboratorService.Application.Queries.GetCollaboratorById
{
    public class GetCollaboratorByIdQueryHandler : IRequestHandler<GetCollaboratorByIdQuery, Collaborator?>
    {
        private readonly ICollaboratorRepository _repository;

        public GetCollaboratorByIdQueryHandler(ICollaboratorRepository repository)
        {
            _repository = repository;
        }

        public async Task<Collaborator?> Handle( GetCollaboratorByIdQuery request,CancellationToken cancellationToken)
        {
            return await _repository.GetCollaboratorByIdAsync(
                request.CollaboratorId);
        }
    }
}