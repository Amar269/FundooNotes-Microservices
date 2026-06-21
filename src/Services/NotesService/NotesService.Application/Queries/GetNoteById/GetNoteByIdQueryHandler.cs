using MediatR;
using NotesService.Application.DTOs;
using NotesService.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotesService.Application.Queries.GetNoteById
{
    public class GetNoteByIdQueryHandler :
        IRequestHandler<GetNoteByIdQuery, NoteResponse?>
    {
        private readonly INoteRepository _noteRepository;

        public GetNoteByIdQueryHandler(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public async Task<NoteResponse?> Handle(
            GetNoteByIdQuery request,
            CancellationToken cancellationToken)
        {
            var note =
                await _noteRepository.GetNoteByIdAsync(request.NoteId);

            if (note == null)
            {
                return null;
            }

            return new NoteResponse
            {
                NoteId = note.NoteId,
                Title = note.Title,
                Description = note.Description,
                IsPin = note.IsPin,
                IsArchive = note.IsArchive,
                IsTrash = note.IsTrash,
                Color = note.Color,
                CreatedAt = note.CreatedAt
            };
        }

    }

}