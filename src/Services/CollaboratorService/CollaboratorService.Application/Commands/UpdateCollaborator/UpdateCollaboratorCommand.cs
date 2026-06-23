using System;
using System.Collections.Generic;
using System.Text;
using CollaboratorService.Application.DTOs;
using MediatR;

namespace CollaboratorService.Application.Commands.UpdateCollaborator
{
    public class UpdateCollaboratorCommand : IRequest<string>
    {
        public long CollaboratorId { get; set; }

        public UpdateCollaboratorDto Request { get; set; } = null!;
    }
}
