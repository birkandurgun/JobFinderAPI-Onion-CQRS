using JobFinderAPI.Application.Interfaces.CommandQuery;
using JobFinderAPI.Application.Interfaces.UnitOfWorks;
using JobFinderAPI.Domain.Entities.Common.User;
using JobFinderAPI.Domain.Shared;

namespace JobFinderAPI.Application.Features.SystemUsers.Commands.VerifyAccount
{
    public class ActivateEmailCommandHandler : ICommandHandler<ActivateEmailCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public ActivateEmailCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(ActivateEmailCommand command, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.ReadRepository<SystemUser>().GetSingleAsync(u => u.Email == command.Email);

            if (user == null)
                return Result.Fail("Incorrect email address.");

            if (user.EmailVerificationToken != command.VerificationCode)
                return Result.Fail("Incorrect verification code.");

            if (user.IsEmailVerified)
                return Result.Fail("Email is already verified.");

            user.IsEmailVerified = true;
            user.EmailVerificationToken = null;

            _unitOfWork.WriteRepository<SystemUser>().Update(user);

            if (await _unitOfWork.SaveAsync() == 0)
                return Result.Fail("Failed to update user.");

            return Result.Ok();
        }
    }
}
