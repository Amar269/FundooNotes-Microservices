using MediatR;
using NotesService.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotesService.Application.Queries.GetNoteById
{
    public  class GetNoteByIdQuery : IRequest<NoteResponse?>
    {
        public long NoteId { get; set; }
    }
}
