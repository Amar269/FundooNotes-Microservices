using System;
using System.Collections.Generic;
using System.Text;
using CollaboratorService.Application.DTOs;

namespace CollaboratorService.Application.Interfaces;

public interface IUserServiceClient
{
    Task<UserDetailsDto?> GetUserByEmailAsync(string email);
}
