using System;
using System.Collections.Generic;
using System.Text;
using CollaboratorService.Application.Interfaces;
using CollaboratorService.Domain.Entities;
using MediatR;

namespace CollaboratorService.Application.Queries.GetCollaboratorsByNoteId
{
    public class GetCollaboratorsByNoteIdQueryHandler :
        IRequestHandler<GetCollaboratorsByNoteIdQuery, IEnumerable<Collaborator>>
    {
        private readonly ICollaboratorRepository _repository;

        public GetCollaboratorsByNoteIdQueryHandler(
            ICollaboratorRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Collaborator>> Handle(
            GetCollaboratorsByNoteIdQuery request,
            CancellationToken cancellationToken)
        {
            return await _repository
                .GetCollaboratorsByNoteIdAsync(request.NoteId);
        }
    }
}