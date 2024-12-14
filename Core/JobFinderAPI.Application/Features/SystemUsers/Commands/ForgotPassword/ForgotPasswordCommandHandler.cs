using JobFinderAPI.Application.Interfaces.CommandQuery;
using JobFinderAPI.Application.Interfaces.Services;
using JobFinderAPI.Application.Interfaces.UnitOfWorks;
using JobFinderAPI.Domain.Entities.Common.User;
using JobFinderAPI.Domain.Shared;

namespace JobFinderAPI.Application.Features.SystemUsers.Commands.ForgotPassword
{
    public class ForgotPasswordCommandHandler : ICommandHandler<ForgotPasswordCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPasswordHasher _passwordHasher;

        public ForgotPasswordCommandHandler(IUnitOfWork unitOfWork, IPasswordHasher passwordHasher)
        {
            _unitOfWork = unitOfWork;
            _passwordHasher = passwordHasher;
        }
        public async Task<Result> Handle(ForgotPasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.ReadRepository<SystemUser>()
                .GetSingleAsync(u => u.ResetToken == request.ResetToken);

            if (user == null)
                return Result.Fail("Invalid reset token.");

            if (user.ResetTokenExpiration > DateTime.Now)
                return Result.Fail("Reset Token Expired");

            var salt = user.PasswordSalt;
            user.PasswordHash = _passwordHasher.Hash(request.NewPassword, salt);
            user.ResetToken = null;
            user.ResetTokenExpiration = null;

            _unitOfWork.WriteRepository<SystemUser>().Update(user);

            if (await _unitOfWork.SaveAsync() == 0)
                return Result.Fail("Failed to update password.");

            return Result.Ok();
        }
    }
}
