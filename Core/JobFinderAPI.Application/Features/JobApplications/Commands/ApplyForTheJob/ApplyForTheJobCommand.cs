using JobFinderAPI.Application.Interfaces.CommandQuery;

namespace JobFinderAPI.Application.Features.JobApplications.Commands.ApplyForTheJob
{
    public class ApplyForTheJobCommand : ICommand
    {
        public Guid ApplicantId { get; set; }
        public Guid JobPostingId { get; set; }
    }
}
