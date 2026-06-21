using System;
using System.Collections.Generic;
using System.Text;

namespace NotesService.Application.DTOs
{
    public class NoteResponse
    {
        public long NoteId { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public bool IsPin { get; set; }

        public bool IsArchive { get; set; }

        public bool IsTrash { get; set; }
    }
}
