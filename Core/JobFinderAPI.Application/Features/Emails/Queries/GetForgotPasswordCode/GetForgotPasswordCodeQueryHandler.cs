using JobFinderAPI.Application.EmailBody;
using JobFinderAPI.Application.Interfaces.CommandQuery;
using JobFinderAPI.Application.Interfaces.Services;
using JobFinderAPI.Application.Interfaces.UnitOfWorks;
using JobFinderAPI.Domain.Entities.Common.User;
using JobFinderAPI.Domain.Shared;

namespace JobFinderAPI.Application.Features.Emails.Queries.GetForgotPasswordCode
{
    public class GetForgotPasswordCodeQueryHandler : IQueryHandler<GetForgotPasswordCodeQuery, GetForgotPasswordCodeResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMailService _emailService;

        public GetForgotPasswordCodeQueryHandler(IUnitOfWork unitOfWork, IMailService emailService)
        {
            _unitOfWork = unitOfWork;
            _emailService = emailService;
        }

        public async Task<Result<GetForgotPasswordCodeResponse>> Handle(GetForgotPasswordCodeQuery request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.ReadRepository<SystemUser>()
                .GetSingleAsync(u => u.Email == request.Email);

            if (user == null)
                return Result.Fail<GetForgotPasswordCodeResponse>("User not found.");

            user.ResetToken = Guid.NewGuid().ToString();
            user.ResetTokenExpiration = DateTime.UtcNow.AddHours(1);

            var email = user.Email;
            var token = user.ResetToken;

            _unitOfWork.WriteRepository<SystemUser>().Update(user);
            if (await _unitOfWork.SaveAsync() == 0)
                return Result.Fail<GetForgotPasswordCodeResponse>("Failed to save reset token.");

            try
            {
                var body = EmailForgotPasswordBody.GetForgotPasswordCodeTemplate(token);
                _emailService.SendMailAsync(email,"Forgot Password?", body);
                return Result.Ok(new GetForgotPasswordCodeResponse { IsEmailSent = true });
            }
            catch (Exception ex)
            {
                return Result.Fail<GetForgotPasswordCodeResponse>($"Failed to send email: {ex.Message}");
            }
        }
    }
}
