using NotesService.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotesService.Application.Interfaces
{
    public interface INoteService
    {
        Task<NoteResponse> CreateNoteAsync(CreateNoteRequest request,long userId);
    }
}
