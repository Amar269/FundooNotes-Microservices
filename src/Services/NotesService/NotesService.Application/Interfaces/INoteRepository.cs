using NotesService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotesService.Application.Interfaces
{
    public interface INoteRepository
    {
        Task<Note> CreateNoteAsync(Note note);
        Task<IEnumerable<Note>> GetAllNotesAsync(long userId);

        Task<Note?> GetNoteByIdAsync(long noteId);

        Task UpdateNoteAsync(Note note);

        Task DeleteNoteAsync(Note note);
    }
}

