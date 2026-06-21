using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotesService.Application.Commands.PinNote
{
    public class PinNoteCommand : IRequest<bool>
    {
        public long NoteId { get; set; }
    }
    
}
