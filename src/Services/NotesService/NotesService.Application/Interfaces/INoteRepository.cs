using NotesService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotesService.Application.Interfaces
{
    public interface INoteRepository
    {
        Task<Note> CreateNoteAsync(Note note);
    }
}

