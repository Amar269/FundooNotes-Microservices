using System;
using System.Collections.Generic;
using System.Text;
using CollaboratorService.Domain.Entities;
using MediatR;

namespace CollaboratorService.Application.Queries.GetSharedNotes
{
    public class GetSharedNotesQuery : IRequest<IEnumerable<Collaborator>>
    {
        public long UserId { get; set; }
    }
}