using System;
using System.Collections.Generic;
using System.Text;

namespace UserService.Application.DTOs
{
    public record UserDetailsDto(
    long UserId,
    string FullName,
    string Email
                 );
}
