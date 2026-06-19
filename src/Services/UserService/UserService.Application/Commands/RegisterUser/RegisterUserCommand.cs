using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace UserService.Application.Commands.RegisterUser
{
    public  record RegisterUserCommand
    (
        string FirstName,
        string LastName,
        string Email,
        string Password
    ) : IRequest<bool>;


}
