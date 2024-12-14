using JobFinderAPI.Application.Interfaces.CommandQuery;

namespace JobFinderAPI.Application.Features.Employers.Commands.EmployerLogin
{
    public class EmployerLoginCommand: ICommand
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
