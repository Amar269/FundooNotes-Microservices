using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotesService.Application.Commands.ChangeColor
{
    public class ChangeColorCommand : IRequest<bool>
    {
        public long NoteId { get; set; }

        public string Color { get; set; }
    }
}
