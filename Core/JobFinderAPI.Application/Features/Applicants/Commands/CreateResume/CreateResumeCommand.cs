using JobFinderAPI.Application.Interfaces.CommandQuery;

namespace JobFinderAPI.Application.Features.Applicants.Commands.CreateResume
{
    public class CreateResumeCommand : ICommand
    {
        public string Url { get; set; }
        public Guid ApplicantId { get; set; }
    }
}
