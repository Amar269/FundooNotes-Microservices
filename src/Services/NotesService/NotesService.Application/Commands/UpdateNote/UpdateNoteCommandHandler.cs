using MediatR;
using NotesService.Application.DTOs;
using NotesService.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotesService.Application.Commands.UpdateNote
{
    public class UpdateNoteCommandHandler : IRequestHandler<UpdateNoteCommand, NoteResponse?>
    {
        private readonly INoteRepository _noteRepository;
        private readonly ICacheService _cacheService;

        public UpdateNoteCommandHandler(INoteRepository noteRepository, ICacheService cacheService)
        {
            _noteRepository = noteRepository;
            _cacheService = cacheService;
        }

        public async Task<NoteResponse?> Handle(
            UpdateNoteCommand request,
            CancellationToken cancellationToken)
        {
            var note = await _noteRepository
                .GetNoteByIdAsync(request.NoteId);

            if (note == null)
            {
                return null;
            }

            note.Title = request.Title;
            note.Description = request.Description;
            note.Color = request.Color;
            note.UpdatedAt = DateTime.UtcNow;

            await _noteRepository.UpdateNoteAsync(note);

            var cacheKey = $"Notes_{note.UserId}";
            await _cacheService.RemoveAsync(cacheKey);

            return new NoteResponse
            {
                NoteId = note.NoteId,
                Title = note.Title,
                Description = note.Description,
                Color = note.Color,
                IsPin = note.IsPin,
                IsArchive = note.IsArchive,
                IsTrash = note.IsTrash,
                CreatedAt = note.CreatedAt
            };
        }
    }
}
