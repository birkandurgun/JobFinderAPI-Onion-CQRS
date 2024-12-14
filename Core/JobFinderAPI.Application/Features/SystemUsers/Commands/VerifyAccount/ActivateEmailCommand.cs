using JobFinderAPI.Application.Interfaces.CommandQuery;

namespace JobFinderAPI.Application.Features.SystemUsers.Commands.VerifyAccount
{
    public class ActivateEmailCommand : ICommand
    {
        public string Email { get; set; }
        public string VerificationCode { get; set; }
    }
}
