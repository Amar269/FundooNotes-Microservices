using MediatR;
using NotesService.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotesService.Application.Commands.DeleteNote
{
    public class DeleteNoteCommandHandler : IRequestHandler<DeleteNoteCommand, bool>
    {
        private readonly INoteRepository _noteRepository;
        private readonly ICacheService _cacheService;

        public DeleteNoteCommandHandler( INoteRepository noteRepository , ICacheService cacheService)
        {
            _noteRepository = noteRepository;
            _cacheService = cacheService;

        }

        public async Task<bool> Handle(DeleteNoteCommand request, CancellationToken cancellationToken)
        {
            var note = await _noteRepository .GetNoteByIdAsync(request.NoteId);

            if (note == null)
            {
                return false;
            }

            await _noteRepository.DeleteNoteAsync(note);
            var cacheKey = $"Notes_{note.UserId}";
            await _cacheService.RemoveAsync(cacheKey);

            return true;
            


        }
    }
    
}
