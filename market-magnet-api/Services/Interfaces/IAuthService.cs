using market_magnet_api.Models;
using System.Security.Claims;

namespace market_magnet_api.Services.Interfaces
{
    public interface IAuthService
    {
        string GenerateJwtToken(User user);
        string GenerateRefreshToken();
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    }
}