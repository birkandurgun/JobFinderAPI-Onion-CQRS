using JobFinderAPI.Application.Interfaces.CommandQuery;
using JobFinderAPI.Application.Interfaces.Services;
using JobFinderAPI.Application.Interfaces.UnitOfWorks;
using JobFinderAPI.Domain.Entities.Common.User;
using JobFinderAPI.Domain.Enums;
using JobFinderAPI.Domain.Shared;

namespace JobFinderAPI.Application.Features.Applicants.Commands.ApplicantLogin
{
    public class ApplicantLoginCommandHandler : ICommandHandler<ApplicantLoginCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPasswordHasher _passwordHasher;
        private readonly ITokenService _tokenService;

        public ApplicantLoginCommandHandler(IUnitOfWork unitOfWork, IPasswordHasher passwordHasher, ITokenService tokenService)
        {
            _unitOfWork = unitOfWork;
            _passwordHasher = passwordHasher;
            _tokenService = tokenService;
        }

        public async Task<Result> Handle(ApplicantLoginCommand request, CancellationToken cancellationToken)
        {
            var systemUser = await _unitOfWork.ReadRepository<SystemUser>().GetSingleAsync(u => u.Email == request.Email);
            if (systemUser == null)
                return Result.Fail("Incorrect Email or Password");

            var salt = systemUser.PasswordSalt;
            var requestPasswordHashed = _passwordHasher.Hash(request.Password, salt);

            if (!requestPasswordHashed.Equals(systemUser.PasswordHash))
                return Result.Fail("Incorrect Email or Password");

            if (systemUser.Role != Role.Applicant)
                return Result.Fail("Unauthorized access");

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
