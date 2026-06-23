using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using NotesService.Application.Interfaces;

namespace NotesService.Application.Commands.ArchiveNote
{
    public class ArchiveNoteCommandHandler : IRequestHandler<ArchiveNoteCommand, bool>
    {
        private readonly INoteRepository _noteRepository;
        private readonly ICacheService _cacheService;

        public ArchiveNoteCommandHandler( INoteRepository noteRepository , ICacheService cacheService)
        {
            _noteRepository = noteRepository;
            _cacheService = cacheService;
        }

        public async Task<bool> Handle(
            ArchiveNoteCommand request,
            CancellationToken cancellationToken)
        {
            var note = await _noteRepository
                .GetNoteByIdAsync(request.NoteId);

            if (note == null)
            {
                return false;
            }

            note.IsArchive = !note.IsArchive;

            await _noteRepository.UpdateNoteAsync(note);

            var cacheKey = $"Notes_{note.UserId}";
            await _cacheService.RemoveAsync(cacheKey);

            return true;
        }
    }
}