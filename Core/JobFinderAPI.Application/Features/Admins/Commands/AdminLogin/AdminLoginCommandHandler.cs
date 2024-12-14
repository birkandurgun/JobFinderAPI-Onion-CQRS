using JobFinderAPI.Application.Interfaces.CommandQuery;
using JobFinderAPI.Application.Interfaces.Services;
using JobFinderAPI.Application.Interfaces.UnitOfWorks;
using JobFinderAPI.Domain.Entities.Common.User;
using JobFinderAPI.Domain.Enums;
using JobFinderAPI.Domain.Shared;

namespace JobFinderAPI.Application.Features.Admins.Commands.AdminLogin
{
    public class AdminLoginCommandHandler : ICommandHandler<AdminLoginCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPasswordHasher _passwordHasher;
        private readonly ITokenService _tokenService;

        public AdminLoginCommandHandler(IUnitOfWork unitOfWork, IPasswordHasher passwordHasher, ITokenService tokenService)
        {
            _unitOfWork = unitOfWork;
            _passwordHasher = passwordHasher;
            _tokenService = tokenService;
        }

        public async Task<Result> Handle(AdminLoginCommand request, CancellationToken cancellationToken)
        {
            var systemUser = await _unitOfWork.ReadRepository<SystemUser>().GetSingleAsync(u => u.Email == request.Email);
            if (systemUser == null)
                return Result.Fail("Incorrect Email or Password");

            if (systemUser.Role != Role.Admin)
                return Result.Fail("Unauthorized access");

            var salt = systemUser.PasswordSalt;
            var requestPasswordHashed = _passwordHasher.Hash(request.Password, salt);

            if (!requestPasswordHashed.Equals(systemUser.PasswordHash))
                return Result.Fail("Incorrect Email or Password");

            var token = _tokenService.GenerateToken(systemUser.Id.ToString(), systemUser.Email, systemUser.Role.ToString());
            var refreshToken = _tokenService.GenerateRefreshToken();

            systemUser.RefreshToken = refreshToken;
            _tokenService.SetRefreshToken(systemUser, refreshToken);

            _unitOfWork.WriteRepository<SystemUser>().Update(systemUser);

            if (await _unitOfWork.SaveAsync() == 0)
                return Result.Fail("Saving Error");

            return Result.Ok(token);
        }
    }
}
