using JobFinderAPI.Application.Interfaces.CommandQuery;
using JobFinderAPI.Application.Interfaces.Services;
using JobFinderAPI.Application.Interfaces.UnitOfWorks;
using JobFinderAPI.Domain.Entities.Common.User;
using JobFinderAPI.Domain.Shared;

namespace JobFinderAPI.Application.Features.SystemUsers.Commands.ChangePassword
{
    public class ChangePasswordCommandHandler : ICommandHandler<ChangePasswordCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPasswordHasher _passwordHasher;

        public ChangePasswordCommandHandler(IUnitOfWork unitOfWork, IPasswordHasher passwordHasher)
        {
            _unitOfWork = unitOfWork;
            _passwordHasher = passwordHasher;
        }

        public async Task<Result> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.ReadRepository<SystemUser>()
                .GetSingleAsync(u => u.Email == request.Email);

            if (user == null)
                return Result.Fail("User not found.");

            if(!_passwordHasher.Hash(request.CurrentPassword, user.PasswordSalt).Equals(user.PasswordHash))
                return Result.Fail("Current password is incorrect.");

            var newPasswordHash = _passwordHasher.Hash(request.NewPassword, user.PasswordSalt);

            user.PasswordHash = newPasswordHash;
            _unitOfWork.WriteRepository<SystemUser>().Update(user);

            if (await _unitOfWork.SaveAsync() == 0)
                return Result.Fail("Failed to update password.");

            return Result.Ok();
        }
    }
}
