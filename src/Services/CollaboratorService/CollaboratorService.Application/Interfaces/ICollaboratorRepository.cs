using System;
using System.Collections.Generic;
using System.Text;

using CollaboratorService.Domain.Entities;

namespace CollaboratorService.Application.Interfaces
{
    public interface ICollaboratorRepository
    {
        Task AddCollaboratorAsync(Collaborator collaborator);

        Task RemoveCollaboratorAsync(long collaboratorId);

        Task<IEnumerable<Collaborator>> GetCollaboratorsByNoteIdAsync(long noteId);

        Task<IEnumerable<Collaborator>> GetSharedNotesAsync(long userId);

        Task<Collaborator?> GetCollaboratorByIdAsync(long collaboratorId);

        Task UpdateCollaboratorAsync(Collaborator collaborator);
    }
}
