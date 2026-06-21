using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace NotesService.Application.Commands.AddReminder
{
    public class AddReminderCommand : IRequest<bool>
    {
        public long NoteId { get; set; }

        public DateTime Reminder { get; set; }
    }
}