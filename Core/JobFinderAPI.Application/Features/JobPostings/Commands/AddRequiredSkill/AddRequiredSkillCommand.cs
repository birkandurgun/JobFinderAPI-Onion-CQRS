using JobFinderAPI.Application.Interfaces.CommandQuery;

namespace JobFinderAPI.Application.Features.JobPostings.Commands.AddRequiredSkill
{
    public class AddRequiredSkillCommand : ICommand
    {
        public Guid JobPostingId { get; set; }
        public Guid SkillId { get; set; }
    }
}
