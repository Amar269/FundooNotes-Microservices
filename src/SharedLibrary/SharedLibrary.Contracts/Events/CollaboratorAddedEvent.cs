using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLibrary.Contracts.Events;

public class CollaboratorAddedEvent
{
    public long NoteId { get; set; }

    public int OwnerUserId { get; set; }

    public int CollaboratorUserId { get; set; }

    public string CollaboratorEmail { get; set; } = string.Empty;

    public string Permission { get; set; } = string.Empty;
}
