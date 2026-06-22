using System;
using System.Collections.Generic;
using System.Text;
using CollaboratorService.Application.DTOs;
using CollaboratorService.Application.Interfaces;
using System.Net.Http.Json;

namespace CollaboratorService.Infrastructure.Services;

public class UserServiceClient : IUserServiceClient
{
    private readonly HttpClient _httpClient;

    public UserServiceClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<UserDetailsDto?> GetUserByEmailAsync(string email)
    {
        return await _httpClient.GetFromJsonAsync<UserDetailsDto>( $"api/User/email/{email}");
    }
}
