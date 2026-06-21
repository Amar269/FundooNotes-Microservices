using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace NotesService.Application.Commands.DeleteNote
{
     public class DeleteNoteCommandHandler
    {
        public long NoteId { get; set; }
    }
}
