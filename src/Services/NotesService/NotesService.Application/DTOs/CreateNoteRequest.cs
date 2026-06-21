using System;
using System.Collections.Generic;
using System.Text;

namespace NotesService.Application.DTOs
{
    public class CreateNoteRequest
    {
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string? Color { get; set; }

        public DateTime? Reminder { get; set; }

        public string? Image { get; set; }
    }
}
