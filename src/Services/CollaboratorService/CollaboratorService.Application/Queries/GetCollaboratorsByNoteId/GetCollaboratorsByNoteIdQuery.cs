using System;
using System.Collections.Generic;
using System.Text;
using CollaboratorService.Domain.Entities;
using MediatR;

namespace CollaboratorService.Application.Queries.GetCollaboratorsByNoteId
{
    public class GetCollaboratorsByNoteIdQuery : IRequest<IEnumerable<Collaborator>>
    {
        public long NoteId { get; set; }
    }
}