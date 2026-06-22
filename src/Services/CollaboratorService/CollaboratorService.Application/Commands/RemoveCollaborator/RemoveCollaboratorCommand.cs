using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace CollaboratorService.Application.Commands.RemoveCollaborator
{
    public class RemoveCollaboratorCommand : IRequest<string>
    {
        public long CollaboratorId { get; set; }
    }
}