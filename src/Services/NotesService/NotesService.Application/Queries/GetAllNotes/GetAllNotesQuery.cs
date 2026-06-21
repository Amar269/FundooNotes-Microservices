using MediatR;
using NotesService.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotesService.Application.Queries.GetAllNotes
{
    public class GetAllNotesQuery : IRequest<List<NoteResponse>>
    {
        public int UserId { get; set; }
    }
}
