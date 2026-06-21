using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using NotesService.Application.Interfaces;

namespace NotesService.Application.Commands.AddReminder
{
    public class AddReminderCommandHandler : IRequestHandler<AddReminderCommand, bool>
    {
        private readonly INoteRepository _noteRepository;

        public AddReminderCommandHandler(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public async Task<bool> Handle(AddReminderCommand request,CancellationToken cancellationToken)
        {
            var note = await _noteRepository
                .GetNoteByIdAsync(request.NoteId);

            if (note == null)
            {
                return false;
            }

            note.Reminder = request.Reminder;

            await _noteRepository.UpdateNoteAsync(note);

            return true;
        }
    }
}
