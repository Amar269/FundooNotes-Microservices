using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLibrary.Contracts.Events;
public class UserRegisteredEvent
{
    public int UserId { get; set; }

    public string FullName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;
}

