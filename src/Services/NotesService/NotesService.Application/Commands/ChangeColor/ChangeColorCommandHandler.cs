using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using NotesService.Application.Interfaces;

namespace NotesService.Application.Commands.ChangeColor
{
    public class ChangeColorCommandHandler :
        IRequestHandler<ChangeColorCommand, bool>
    {
        private readonly INoteRepository _noteRepository;

        public ChangeColorCommandHandler(
            INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public async Task<bool> Handle(
            ChangeColorCommand request,
            CancellationToken cancellationToken)
        {
            var note = await _noteRepository
                .GetNoteByIdAsync(request.NoteId);

            if (note == null)
            {
                return false;
            }

            note.Color = request.Color;

            await _noteRepository.UpdateNoteAsync(note);

            return true;
        }
    }
}