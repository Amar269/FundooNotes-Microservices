using MediatR;
using NotesService.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotesService.Application.Commands.CreateNote
{
    public class CreateNoteCommand : IRequest<NoteResponse>
    {
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string? Color { get; set; }

        public DateTime? Reminder { get; set; }

        public long UserId { get; set; }

    }
}
