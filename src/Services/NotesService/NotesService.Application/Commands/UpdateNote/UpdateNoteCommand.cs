using MediatR;
using NotesService.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotesService.Application.Commands.UpdateNote
{
    public class UpdateNoteCommand : IRequest<NoteResponse?>
    {
        public long NoteId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Color { get; set; }
    }
}
