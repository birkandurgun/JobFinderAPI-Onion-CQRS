using JobFinderAPI.Application.Interfaces.CommandQuery;
using JobFinderAPI.Application.Interfaces.Services;
using JobFinderAPI.Application.Interfaces.UnitOfWorks;
using JobFinderAPI.Domain.Entities;
using JobFinderAPI.Domain.Entities.Common.User;
using JobFinderAPI.Domain.Shared;
using JobFinderAPI.Domain.Enums;

namespace JobFinderAPI.Application.Features.Applicants.Commands.ApplicantRegister
{
    public class ApplicantRegisterCommandHandler : ICommandHandler<ApplicantRegisterCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPasswordHasher _passwordHasher;
        public ApplicantRegisterCommandHandler(IUnitOfWork unitOfWork, IPasswordHasher passwordHasher)
        {
            _unitOfWork = unitOfWork;
            _passwordHasher = passwordHasher;
        }

        public async Task<Result> Handle(ApplicantRegisterCommand request, CancellationToken cancellationToken)
        {
            var userExistsWithEmail = await _unitOfWork.ReadRepository<SystemUser>().GetSingleAsync(u => u.Email == request.Email);

            if (userExistsWithEmail != null)
                return Result.Fail("A user with this email already exists.");

            var userExistsWithPhone = await _unitOfWork.ReadRepository<SystemUser>().GetSingleAsync(u => u.CountryCode == request.CountryCode && u.PhoneNumber == request.PhoneNumber);

            if (userExistsWithPhone != null)
                return Result.Fail("A user with this phone already exists.");

            var salt = _passwordHasher.CreateSalt();
            var hashedPassword = _passwordHasher.Hash(request.Password, salt);

            await _unitOfWork.WriteRepository<Applicant>().AddAsync(new Applicant
            {
                Id = Guid.NewGuid(),
                Email = request.Email,
                CountryCode = request.CountryCode,
                PhoneNumber = request.PhoneNumber,
                PasswordHash = hashedPassword,
                PasswordSalt = salt,
                FirstName = request.FirstName,
                LastName = request.LastName,
                EmailVerificationToken = Guid.NewGuid().ToString(),
                IsEmailVerified = false,
                Role = Role.Applicant
            });

            if (await _unitOfWork.SaveAsync() == 0)
                return Result.Fail("Saving Error");

            return Result.Ok();
        }
    }
}
