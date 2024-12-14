using JobFinderAPI.Application.Interfaces.CommandQuery;

namespace JobFinderAPI.Application.Features.Applicants.Commands.ApplicantLogin
{
    public class ApplicantLoginCommand : ICommand
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
