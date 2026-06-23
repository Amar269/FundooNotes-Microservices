using MediatR;
using NotesService.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotesService.Application.Commands.PinNote
{
    public class PinNoteCommandHandler : IRequestHandler<PinNoteCommand, bool>
    {
        private readonly INoteRepository _noteRepository;
        private readonly ICacheService _cacheService;

        public PinNoteCommandHandler( INoteRepository noteRepository , ICacheService cacheService)
        {
            _noteRepository = noteRepository;
            _cacheService = cacheService;
        }

        public async Task<bool> Handle(
            PinNoteCommand request,
            CancellationToken cancellationToken)
        {

            var note = await _noteRepository.GetNoteByIdAsync(request.NoteId);

            if (note == null)
            {
                return false;
            }

            note.IsPin = !note.IsPin;

            await _noteRepository.UpdateNoteAsync(note);

            var cacheKey = $"Notes_{note.UserId}";
            await _cacheService.RemoveAsync(cacheKey);

            return true;

        }
    }
}
