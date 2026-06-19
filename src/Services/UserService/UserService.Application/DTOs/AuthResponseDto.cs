using System;
using System.Collections.Generic;
using System.Text;

namespace UserService.Application.DTOs
{
    public record AuthResponseDto
    (
        string Token,
        string Email,
        string FullName
    );

}
