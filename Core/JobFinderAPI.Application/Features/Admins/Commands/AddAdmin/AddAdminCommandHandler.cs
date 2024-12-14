using JobFinderAPI.Application.Interfaces.CommandQuery;
using JobFinderAPI.Application.Interfaces.Services;
using JobFinderAPI.Application.Interfaces.UnitOfWorks;
using JobFinderAPI.Domain.Entities.Common.User;
using JobFinderAPI.Domain.Entities;
using JobFinderAPI.Domain.Enums;
using JobFinderAPI.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobFinderAPI.Application.Features.Admins.Commands.AddAdmin
{
    public class AddAdminCommandHandler : ICommandHandler<AddAdminCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPasswordHasher _passwordHasher;

        public AddAdminCommandHandler(IUnitOfWork unitOfWork, IPasswordHasher passwordHasher)
        {
            _unitOfWork = unitOfWork;
            _passwordHasher = passwordHasher;
        }

        public async Task<Result> Handle(AddAdminCommand request, CancellationToken cancellationToken)
        {
            var existingAdmin = await _unitOfWork.ReadRepository<SystemUser>().GetSingleAsync(u => u.Email == request.Email);
            if (existingAdmin != null)
                return Result.Fail("Admin with this email already exists.");

            var userExistsWithPhone = await _unitOfWork.ReadRepository<SystemUser>().GetSingleAsync(u => u.CountryCode == request.CountryCode && u.PhoneNumber == request.PhoneNumber);

            if (userExistsWithPhone != null)
                return Result.Fail("A user with this phone already exists.");

            var salt = _passwordHasher.CreateSalt();
            var hashedPassword = _passwordHasher.Hash(request.Password, salt);

            var newAdmin = new Admin
            {
                Email = request.Email,
                Username = request.Username,
                PasswordHash = hashedPassword,
                PasswordSalt = salt,
                CountryCode = request.CountryCode,
                PhoneNumber = request.PhoneNumber,
                Role = Role.Admin,
                IsEmailVerified = true
            };

            await _unitOfWork.WriteRepository<Admin>().AddAsync(newAdmin);

            if (await _unitOfWork.SaveAsync() == 0)
                return Result.Fail("Failed to create the admin.");

            return Result.Ok();
        }

    }
}
