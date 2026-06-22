using System;
using System.Collections.Generic;
using System.Text;

using CollaboratorService.Application.DTOs;
using MediatR;

namespace CollaboratorService.Application.Commands.AddCollaborator
{
    public class AddCollaboratorCommand : IRequest<string>
    {
        public long OwnerUserId { get; set; }

        public AddCollaboratorRequest Request { get; set; }
            = new AddCollaboratorRequest();
    }
}