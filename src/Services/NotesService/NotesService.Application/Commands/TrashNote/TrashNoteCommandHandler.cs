using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using NotesService.Application.Interfaces;

namespace NotesService.Application.Commands.TrashNote
{
    public class TrashNoteCommandHandler :
        IRequestHandler<TrashNoteCommand, bool>
    {
        private readonly INoteRepository _noteRepository;

        public TrashNoteCommandHandler(
            INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public async Task<bool> Handle( TrashNoteCommand request,CancellationToken cancellationToken)
        {
            return true;

        }
    }
}