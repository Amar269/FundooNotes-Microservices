using Microsoft.EntityFrameworkCore;
using NotesService.Application.Interfaces;
using NotesService.Domain.Entities;
using NotesService.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotesService.Infrastructure.Repositories
{
    public class NoteRepository : INoteRepository
    {
        private readonly NotesDbContext _context;

        public NoteRepository(NotesDbContext Context)
        {
            _context = Context;

        }
        public async Task<Note> CreateNoteAsync(Note note)
        {
            await _context.Notes.AddAsync(note);
            await _context.SaveChangesAsync();

            return note;
        }

        public async Task DeleteNoteAsync(Note note)
        {
            _context.Notes.Remove(note);
            await _context.SaveChangesAsync();
        }

        public async  Task<IEnumerable<Note>> GetAllNotesAsync(long userId)
        {
            return await _context.Notes
            .Where(x => x.UserId == userId)
            .ToListAsync();

        }

        public async Task<Note?> GetNoteByIdAsync(long noteId)
        {
            return await _context.Notes
            .FirstOrDefaultAsync(x => x.NoteId == noteId);
        }

        public async Task UpdateNoteAsync(Note note)
        {
            _context.Notes.Update(note);
            await _context.SaveChangesAsync();
        }
    }
}
