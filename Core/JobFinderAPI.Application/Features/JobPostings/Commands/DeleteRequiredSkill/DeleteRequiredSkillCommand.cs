using JobFinderAPI.Application.Interfaces.CommandQuery;

namespace JobFinderAPI.Application.Features.JobPostings.Commands.DeleteRequiredSkill
{
    public class DeleteRequiredSkillCommand : ICommand
    {
        public Guid JobPostingId { get; set; }
        public Guid SkillId { get; set; }
    }
}
