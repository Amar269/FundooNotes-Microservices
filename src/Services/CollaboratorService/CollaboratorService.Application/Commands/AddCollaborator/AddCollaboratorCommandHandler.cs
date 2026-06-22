using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace CollaboratorService.Application.Commands.AddCollaborator
{
    public class AddCollaboratorCommandHandler :
        IRequestHandler<AddCollaboratorCommand, string>
    {
        public async Task<string> Handle(
            AddCollaboratorCommand request,
            CancellationToken cancellationToken)
        {
            return "Collaborator Added";
        }
    }
}