using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotesService.Application.Commands.DeleteNote
{
    public class DeleteNoteCommand : IRequest<bool>

    {
        public long NoteId { get; set; }
    }
}
