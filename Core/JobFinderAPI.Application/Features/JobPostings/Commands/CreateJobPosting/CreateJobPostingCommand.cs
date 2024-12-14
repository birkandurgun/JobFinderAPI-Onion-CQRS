using JobFinderAPI.Application.Interfaces.CommandQuery;
using JobFinderAPI.Domain.Enums;

namespace JobFinderAPI.Application.Features.JobPostings.Commands.CreateJobPosting
{
    public class CreateJobPostingCommand : ICommand
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid EmployerId { get; set; }
        public List<Guid> RequiredSkillIds { get; set; }
        public WorkPreference WorkPreference { get; set; }
        public Sector Sector { get; set; }
    }
}
