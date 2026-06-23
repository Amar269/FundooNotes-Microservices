using MediatR;
using NotesService.Application.DTOs;
using NotesService.Application.Interfaces;
using NotesService.Domain.Entities;

namespace NotesService.Application.Commands.CreateNote;

public class CreateNoteCommandHandler : IRequestHandler<CreateNoteCommand, NoteResponse>
{
    private readonly INoteRepository _noteRepository;
    private readonly ICacheService _cacheService;

    public CreateNoteCommandHandler(INoteRepository noteRepository , ICacheService cacheService)
    {
        _noteRepository = noteRepository;
        _cacheService = cacheService;
    }

    public async Task<NoteResponse> Handle(
        CreateNoteCommand request,
        CancellationToken cancellationToken)
    {
        var note = new Note
        {
            Title = request.Title,
            Description = request.Description,
            Color = request.Color,
            Reminder = request.Reminder,
            UserId = request.UserId,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };
        var cacheKey = $"Notes_{request.UserId}";
        await _cacheService.RemoveAsync(cacheKey);
        var createdNote = await _noteRepository.CreateNoteAsync(note);

        return new NoteResponse
        {
            NoteId = createdNote.NoteId,
            Title = createdNote.Title,
            Description = createdNote.Description,
            Color = createdNote.Color,
            CreatedAt = createdNote.CreatedAt
        };
    }
}