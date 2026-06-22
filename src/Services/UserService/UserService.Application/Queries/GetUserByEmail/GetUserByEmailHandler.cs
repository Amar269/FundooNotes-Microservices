using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using UserService.Application.DTOs;
using UserService.Application.Interfaces;

namespace UserService.Application.Queries.GetUserByEmail;

public class GetUserByEmailHandler
    : IRequestHandler<GetUserByEmailQuery, UserDetailsDto>
{
    private readonly IUserRepository _userRepository;

    public GetUserByEmailHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserDetailsDto> Handle(
        GetUserByEmailQuery request,
        CancellationToken cancellationToken)
    {
        var user = await _userRepository
            .GetUserByEmailAsync(request.Email);

        if (user == null)
            throw new Exception("User not found");

        return new UserDetailsDto( user.UserId,$"{user.FirstName} {user.LastName}", user.Email);
    }
}