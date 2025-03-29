using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;

namespace Planify.Services;

public class UserService
{
    private readonly AuthenticationStateProvider _authenticationStateProvider;

    public UserService(AuthenticationStateProvider authenticationStateProvider)
    {
        _authenticationStateProvider = authenticationStateProvider;
    }

    public async Task<string?> ObtenerUserId()
    {
        try
        {
            var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;

            if (user.Identity is { IsAuthenticated: true })
            {
                return user.FindFirst(ClaimTypes.NameIdentifier)?.Value 
                       ?? user.FindFirst("sub")?.Value;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error obteniendo UserId: {ex.Message}");
        }
        return null;
    }
}