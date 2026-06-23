using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using NotesService.Application.Interfaces;

namespace NotesService.Application.Commands.TrashNote
{
    public class TrashNoteCommandHandler :
        IRequestHandler<TrashNoteCommand, bool>
    {
        private readonly INoteRepository _noteRepository;
        private readonly ICacheService _cacheService;

        public TrashNoteCommandHandler(INoteRepository noteRepository, ICacheService cacheService)

        {
            _noteRepository = noteRepository;
            _cacheService = cacheService;
        }

        public async Task<bool> Handle( TrashNoteCommand request,CancellationToken cancellationToken)
        {
            var note = await _noteRepository.GetNoteByIdAsync(request.NoteId);

            if (note == null)
            {
                return false;
            }

            note.IsTrash = !note.IsTrash;

            await _noteRepository.UpdateNoteAsync(note);

            var cacheKey = $"Notes_{note.UserId}";
            await _cacheService.RemoveAsync(cacheKey);

            return true;

        }
    }
}