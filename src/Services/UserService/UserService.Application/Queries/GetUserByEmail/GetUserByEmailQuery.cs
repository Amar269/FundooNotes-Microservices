using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using UserService.Application.DTOs;
using MediatR;
using UserService.Application.DTOs;

namespace UserService.Application.Queries.GetUserByEmail;

public class GetUserByEmailQuery : IRequest<UserDetailsDto>
{
    public string Email { get; set; }

    public GetUserByEmailQuery(string email)
    {
        Email = email;
    }
}
