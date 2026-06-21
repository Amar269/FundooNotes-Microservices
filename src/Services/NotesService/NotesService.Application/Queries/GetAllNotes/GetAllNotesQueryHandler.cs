using MediatR;
using NotesService.Application.DTOs;
using NotesService.Application.Interfaces;
using System.Linq;

namespace NotesService.Application.Queries.GetAllNotes
{
    public class GetAllNotesQueryHandler :IRequestHandler<GetAllNotesQuery, List<NoteResponse>>
    {
        private readonly INoteRepository _noteRepository;

        public GetAllNotesQueryHandler(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public async Task<List<NoteResponse>> Handle(
            GetAllNotesQuery request,
            CancellationToken cancellationToken)
        {
            var notes = await _noteRepository.GetAllNotesAsync(request.UserId);

            return notes.Select(note => new NoteResponse
            {
                NoteId = note.NoteId,
                Title = note.Title,
                Description = note.Description,
                Color = note.Color,
                CreatedAt = note.CreatedAt,
                IsPin = note.IsPin,
                IsArchive = note.IsArchive,
                IsTrash = note.IsTrash
            }).ToList();
        }
    }
    
}