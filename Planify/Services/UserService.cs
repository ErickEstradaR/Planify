using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Planify.Data;

namespace Planify.Services
{
    public class UserService
    {
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private readonly UserManager<ApplicationUser> _userManager;
        
        public UserService(AuthenticationStateProvider authenticationStateProvider, UserManager<ApplicationUser> userManager)
        {
            _authenticationStateProvider = authenticationStateProvider;
            _userManager = userManager;  // Inyectamos el UserManager
        }

        // Método para obtener el UserId del usuario autenticado
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
        
        public async Task<List<string>> ObtenerRol(ApplicationUser user)
        {
            var roles = await _userManager.GetRolesAsync(user);
            return roles.ToList(); 
        }
        
        public async Task<ApplicationUser?> EncontrarUsuario(string userId)
        {
            if (string.IsNullOrEmpty(userId))
                return null;

            return await _userManager.FindByIdAsync(userId);
        }
    }
}