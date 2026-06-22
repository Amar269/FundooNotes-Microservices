using System;
using System.Collections.Generic;
using System.Text;

namespace CollaboratorService.Application.DTOs
{
    public class AddCollaboratorRequest
    {
        public long NoteId { get; set; }

        public string Email { get; set; } = string.Empty;
    }
}