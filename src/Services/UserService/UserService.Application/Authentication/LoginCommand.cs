using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using UserService.Application.DTOs;


namespace UserService.Application.Authentication
{
    public record LoginCommand(string Email,string Password): IRequest<AuthResponseDto>;

    
}
