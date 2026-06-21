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

        public ArchiveNoteCommandHandler(
            INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
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

            return true;
        }
    }
}