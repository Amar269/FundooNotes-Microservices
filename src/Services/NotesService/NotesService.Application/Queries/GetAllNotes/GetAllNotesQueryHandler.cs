using MediatR;
using NotesService.Application.DTOs;
using NotesService.Application.Interfaces;
using System.Linq;
using NotesService.Application.Interfaces;

namespace NotesService.Application.Queries.GetAllNotes
{
    public class GetAllNotesQueryHandler :IRequestHandler<GetAllNotesQuery, List<NoteResponse>>
    {
        private readonly INoteRepository _noteRepository;
        private readonly ICacheService _cacheService;

        public GetAllNotesQueryHandler(INoteRepository noteRepository , ICacheService cacheService)
        {
            _noteRepository = noteRepository;
            _cacheService = cacheService;
        }

        public async Task<List<NoteResponse>> Handle(
            GetAllNotesQuery request,
            CancellationToken cancellationToken)
        {
            var cacheKey = $"Notes_{request.UserId}";
            var cachedNotes = await _cacheService.GetAsync<List<NoteResponse>>(cacheKey);
            if (cachedNotes != null)
            {
                return cachedNotes;
            }

            var notes = await _noteRepository.GetAllNotesAsync(request.UserId);
           

            var response =  notes.Select(note => new NoteResponse
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

            await _cacheService.SetAsync(cacheKey,response,TimeSpan.FromMinutes(5));

            return response;
        }
    }
    
}