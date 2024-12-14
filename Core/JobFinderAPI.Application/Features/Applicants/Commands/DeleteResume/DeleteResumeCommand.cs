using JobFinderAPI.Application.Interfaces.CommandQuery;

namespace JobFinderAPI.Application.Features.Applicants.Commands.DeleteResume
{
    public class DeleteResumeCommand : ICommand
    {
        public Guid ApplicantId { get; set; }
    }
}
