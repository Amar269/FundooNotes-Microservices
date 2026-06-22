using System;
using System.Collections.Generic;
using System.Text;
using CollaboratorService.Application.Interfaces;
using CollaboratorService.Domain.Entities;
using MediatR;

namespace CollaboratorService.Application.Queries.GetSharedNotes
{
    public class GetSharedNotesQueryHandler : IRequestHandler<GetSharedNotesQuery, IEnumerable<Collaborator>>
    {
        private readonly ICollaboratorRepository _repository;

        public GetSharedNotesQueryHandler(ICollaboratorRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Collaborator>> Handle(GetSharedNotesQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetSharedNotesAsync(request.UserId);
        }
    }
}