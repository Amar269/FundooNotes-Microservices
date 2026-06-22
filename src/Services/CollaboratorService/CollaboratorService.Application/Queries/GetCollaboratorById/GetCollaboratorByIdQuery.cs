using System;
using System.Collections.Generic;
using System.Text;
using CollaboratorService.Domain.Entities;
using MediatR;

namespace CollaboratorService.Application.Queries.GetCollaboratorById
{
    public class GetCollaboratorByIdQuery : IRequest<Collaborator?>
    {
        public long CollaboratorId { get; set; }
    }
}