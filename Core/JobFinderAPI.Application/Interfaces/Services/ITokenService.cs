using JobFinderAPI.Domain.Entities.Common.User;
using System.Security.Claims;

namespace JobFinderAPI.Application.Interfaces.Services
{
    public interface ITokenService
    {
        string GenerateToken(string userId, string email, string userType);
        string GenerateRefreshToken();
        ClaimsPrincipal? GetPrincipalFromExpiredToken(string token);
        void SetRefreshToken(SystemUser systemUser, string refreshToken);
    }
}
