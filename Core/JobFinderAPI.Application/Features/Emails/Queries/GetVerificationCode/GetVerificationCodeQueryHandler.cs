using JobFinderAPI.Application.Interfaces.CommandQuery;
using JobFinderAPI.Application.Interfaces.Services;
using JobFinderAPI.Application.Interfaces.UnitOfWorks;
using JobFinderAPI.Application.Templates;
using JobFinderAPI.Domain.Entities.Common.User;
using JobFinderAPI.Domain.Shared;
using MediatR;

namespace JobFinderAPI.Application.Features.Emails.Queries.GetVerificationCode
{
    public class GetVerificationCodeQueryHandler : IQueryHandler<GetVerificationCodeQuery,GetVerificationCodeResponse>
    {
        private readonly IMailService _mailService;
        private readonly IUnitOfWork _unitOfWork;
        public GetVerificationCodeQueryHandler(IMailService mailService, IUnitOfWork unitOfWork)
        {
            _mailService = mailService;
            _unitOfWork = unitOfWork;
        }
        public async Task<Result<GetVerificationCodeResponse>> Handle(GetVerificationCodeQuery query, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.ReadRepository<SystemUser>().GetSingleAsync(u => u.Email == query.Email);

            if (user == null)
                return Result.Fail<GetVerificationCodeResponse>("User with this email does not exist.");

            var email = user.Email;
            var verificationCode = user.EmailVerificationToken;

            try
            {
                var body = EmailVerificationBody.GetVerificationCodeTemplate(email, verificationCode);
                await _mailService.SendMailAsync(email, "Email Verification", body);
                return Result.Ok(new GetVerificationCodeResponse { IsEmailSent = true });
            }
            catch (Exception ex) 
            {
                return Result.Fail<GetVerificationCodeResponse>("Failed to send verification email.");    
            }
            
        }

    }
}
