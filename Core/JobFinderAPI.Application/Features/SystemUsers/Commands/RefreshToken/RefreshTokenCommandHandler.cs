using JobFinderAPI.Application.Interfaces.CommandQuery;
using JobFinderAPI.Application.Interfaces.Services;
using JobFinderAPI.Application.Interfaces.UnitOfWorks;
using JobFinderAPI.Domain.Entities.Common.User;
using JobFinderAPI.Domain.Shared;
using System.Security.Claims;

namespace JobFinderAPI.Application.Features.SystemUsers.Commands.RefreshToken
{
    public class RefreshTokenCommandHandler : ICommandHandler<RefreshTokenCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITokenService _tokenService;

        public RefreshTokenCommandHandler(IUnitOfWork unitOfWork, ITokenService tokenService)
        {
            _unitOfWork = unitOfWork;
            _tokenService = tokenService;
        }

        public async Task<Result> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            ClaimsPrincipal? principal = _tokenService.GetPrincipalFromExpiredToken(request.AccessToken);

            var userId = principal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var email = principal.FindFirst(ClaimTypes.Email)?.Value;
            var role = principal.FindFirst(ClaimTypes.Role)?.Value;

            if (userId == null)
                return Result.Fail("Invalid token claims.");

            var user = await _unitOfWork.ReadRepository<SystemUser>().GetSingleAsync(u => u.Id.ToString() == userId);

            if (user == null)
                return Result.Fail("User not found.");

            if (user.RefreshToken != request.RefreshToken)
                return Result.Fail("Invalid refresh token.");

            if (user.RefreshTokenExpiryTime < DateTime.UtcNow)
                return Result.Fail("Refresh token has expired.");

            var newAccessToken = _tokenService.GenerateToken(user.Id.ToString(), email, role);
            var newRefreshToken = _tokenService.GenerateRefreshToken();

            _tokenService.SetRefreshToken(user, newRefreshToken);
            _unitOfWork.WriteRepository<SystemUser>().Update(user);

            if (await _unitOfWork.SaveAsync() == 0)
                return Result.Fail("Failed to update refresh token.");

            return Result.Ok(new { AccessToken = newAccessToken});
        }
    }
}
