using System;
using System.Collections.Generic;
using System.Text;

namespace NotesService.Domain.Entities
{
    public  class Note
    {
        public long NoteId { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string? Color { get; set; }

        public DateTime? Reminder { get; set; }

        public string? Image { get; set; }

        public bool IsArchive { get; set; } = false;

        public bool IsPin { get; set; } = false;

        public bool IsTrash { get; set; } = false;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public long UserId { get; set; }
    }
}
