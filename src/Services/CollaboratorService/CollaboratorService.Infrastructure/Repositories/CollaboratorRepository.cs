using System;
using System.Collections.Generic;
using System.Text;

using CollaboratorService.Application.Interfaces;
using CollaboratorService.Domain.Entities;
using CollaboratorService.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace CollaboratorService.Infrastructure.Repositories
{
    public class CollaboratorRepository : ICollaboratorRepository
    {
        private readonly CollaboratorDbContext _context;

        public CollaboratorRepository(CollaboratorDbContext context)
        {
            _context = context;
        }

        public async Task AddCollaboratorAsync(Collaborator collaborator)
        {
            await _context.Collaborators.AddAsync(collaborator);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveCollaboratorAsync(long collaboratorId)
        {
            var collaborator = await _context.Collaborators
                .FirstOrDefaultAsync(x => x.CollaboratorId == collaboratorId);

            if (collaborator != null)
            {
                _context.Collaborators.Remove(collaborator);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Collaborator>> GetCollaboratorsByNoteIdAsync(long noteId)
        {
            return await _context.Collaborators
                .Where(x => x.NoteId == noteId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Collaborator>> GetSharedNotesAsync(long userId)
        {
            return await _context.Collaborators
                .Where(x => x.CollaboratorUserId == userId)
                .ToListAsync();
        }

        public async Task<Collaborator?> GetCollaboratorByIdAsync(long collaboratorId)
        {
            return await _context.Collaborators
                .FirstOrDefaultAsync(x => x.CollaboratorId == collaboratorId);
        }

        public async Task UpdateCollaboratorAsync(Collaborator collaborator)
        {
            _context.Collaborators.Update(collaborator);
            await _context.SaveChangesAsync();
        }
    }
}
