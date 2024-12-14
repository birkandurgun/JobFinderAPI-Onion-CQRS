using JobFinderAPI.Application.Interfaces.CommandQuery;

namespace JobFinderAPI.Application.Features.Emails.Queries.GetForgotPasswordCode
{
    public class GetForgotPasswordCodeQuery : IQuery<GetForgotPasswordCodeResponse>
    {
        public string Email { get; set; }
    }
}
