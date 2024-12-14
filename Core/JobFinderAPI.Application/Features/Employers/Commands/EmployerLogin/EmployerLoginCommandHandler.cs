using JobFinderAPI.Application.Interfaces.CommandQuery;
using JobFinderAPI.Application.Interfaces.Services;
using JobFinderAPI.Application.Interfaces.UnitOfWorks;
using JobFinderAPI.Domain.Entities;
using JobFinderAPI.Domain.Entities.Common.User;
using JobFinderAPI.Domain.Enums;
using JobFinderAPI.Domain.Shared;
using MediatR;
using System.Security.Claims;

namespace JobFinderAPI.Application.Features.Employers.Commands.EmployerLogin
{
    public class EmployerLoginCommandHandler : ICommandHandler<EmployerLoginCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITokenService _tokenService;
        private readonly IPasswordHasher _passwordHasher;

        public EmployerLoginCommandHandler(IUnitOfWork unitOfWork, ITokenService tokenService, IPasswordHasher passwordHasher)
        {
            _unitOfWork = unitOfWork;
            _tokenService = tokenService;
            _passwordHasher = passwordHasher;
        }
        public async Task<Result> Handle(EmployerLoginCommand request, CancellationToken cancellationToken)
        {
            var systemUser = await _unitOfWork.ReadRepository<SystemUser>().GetSingleAsync(u => u.Email == request.Email);

            if (systemUser == null)
                return Result.Fail("Incorrect Email or Password");

            var salt = systemUser.PasswordSalt;
            var requestPasswordHashed = _passwordHasher.Hash(request.Password,salt);

            if(!requestPasswordHashed.Equals(systemUser.PasswordHash))
                return Result.Fail("Incorrect Email or Password");

            if (systemUser.Role != Role.Employer)
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
