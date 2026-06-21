using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotesService.Application.Commands.TrashNote
{
     public class TrashNoteCommand : IRequest<bool>
     {
        public long NoteId { get; set; }
     }

}
