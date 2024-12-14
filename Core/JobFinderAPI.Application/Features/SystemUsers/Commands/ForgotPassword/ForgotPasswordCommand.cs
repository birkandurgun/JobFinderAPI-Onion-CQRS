using JobFinderAPI.Application.Interfaces.CommandQuery;

namespace JobFinderAPI.Application.Features.SystemUsers.Commands.ForgotPassword
{
    public class ForgotPasswordCommand : ICommand
    {
        public string ResetToken { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmNewPassword { get; set; }
    }
}
