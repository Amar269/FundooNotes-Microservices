using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using UserService.Application.DTOs;

namespace UserService.Application.Queries.GetUserByEmail
{
    internal class GetUserByEmailQuery : IRequest<UserDetailsDto>;
    {
    }
}
