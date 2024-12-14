using JobFinderAPI.Application.Interfaces.CommandQuery;

namespace JobFinderAPI.Application.Features.Admins.Commands.AdminLogin
{
    public class AdminLoginCommand : ICommand
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
