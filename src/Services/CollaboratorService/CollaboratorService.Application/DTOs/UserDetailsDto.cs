using System;
using System.Collections.Generic;
using System.Text;
namespace CollaboratorService.Application.DTOs;
public class UserDetailsDto
{
    public int UserId { get; set; }

    public string FullName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;
}