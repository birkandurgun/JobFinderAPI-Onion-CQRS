using JobFinderAPI.Application.Interfaces.CommandQuery;
using JobFinderAPI.Domain.Enums;

namespace JobFinderAPI.Application.Features.JobPostings.Commands.UpdateJobPosting
{
    public class UpdateJobPostingCommand : ICommand
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public WorkPreference WorkPreference { get; set; }
        public Sector Sector { get; set; }
    }
}
