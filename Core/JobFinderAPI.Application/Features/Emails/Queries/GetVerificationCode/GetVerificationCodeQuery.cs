using JobFinderAPI.Application.Interfaces.CommandQuery;

namespace JobFinderAPI.Application.Features.Emails.Queries.GetVerificationCode
{
    public class GetVerificationCodeQuery : IQuery<GetVerificationCodeResponse>
    {
        public string Email { get; set; }
    }
}
