using JobFinderAPI.Application.Interfaces.CommandQuery;
using JobFinderAPI.Application.Interfaces.Services;
using JobFinderAPI.Application.Interfaces.UnitOfWorks;
using JobFinderAPI.Domain.Entities;
using JobFinderAPI.Domain.Entities.Common.User;
using JobFinderAPI.Domain.Shared;
using JobFinderAPI.Domain.Enums;

namespace JobFinderAPI.Application.Features.Employers.Commands.EmployerRegister
{
    public class EmployerRegisterCommandHandler : ICommandHandler<EmployerRegisterCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPasswordHasher _passwordHasher;
        public EmployerRegisterCommandHandler(IUnitOfWork unitOfWork,IPasswordHasher passwordHasher)
        {
            _unitOfWork = unitOfWork;
            _passwordHasher = passwordHasher;
        }
        public async Task<Result> Handle(EmployerRegisterCommand request, CancellationToken cancellationToken)
        {
            var userExistsWithEmail = await _unitOfWork.ReadRepository<SystemUser>().GetSingleAsync(u => u.Email == request.Email);

            if (userExistsWithEmail != null)
                return Result.Fail("A user with this email already exists.");

            var userExistsWithPhone = await _unitOfWork.ReadRepository<SystemUser>().GetSingleAsync(u => u.CountryCode == request.CountryCode && u.PhoneNumber == request.PhoneNumber);

            if (userExistsWithPhone != null)
                return Result.Fail("A user with this phone already exists.");

            var salt = _passwordHasher.CreateSalt();
            var hashedPassword = _passwordHasher.Hash(request.Password, salt);

            await _unitOfWork.WriteRepository<Employer>().AddAsync(new Employer
            {
                Email = request.Email,
                CountryCode = request.CountryCode,
                PhoneNumber = request.PhoneNumber,
                CompanyName = request.CompanyName,
                PasswordHash = hashedPassword,
                PasswordSalt = salt,
                EmailVerificationToken = Guid.NewGuid().ToString(),
                IsEmailVerified = false,
                Role = Role.Employer
            });

            if (await _unitOfWork.SaveAsync() == 0)
                return Result.Fail("Saving Error");

            return Result.Ok();
        }
    }
}
