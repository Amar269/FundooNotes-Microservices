using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotesService.Application.Commands.ArchiveNote
{
    public class ArchiveNoteCommand : IRequest<bool>
    {
        public long NoteId { get; set; }
    }
    
}
