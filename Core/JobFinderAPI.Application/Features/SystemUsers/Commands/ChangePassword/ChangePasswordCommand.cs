using JobFinderAPI.Application.Interfaces.CommandQuery;

namespace JobFinderAPI.Application.Features.SystemUsers.Commands.ChangePassword
{
    public class ChangePasswordCommand : ICommand
    {
        public string Email { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmNewPassword { get; set; }
    }
}
