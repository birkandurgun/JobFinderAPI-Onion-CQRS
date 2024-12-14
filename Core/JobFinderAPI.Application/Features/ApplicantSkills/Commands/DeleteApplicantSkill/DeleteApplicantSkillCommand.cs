using JobFinderAPI.Application.Interfaces.CommandQuery;

namespace JobFinderAPI.Application.Features.ApplicantSkills.Commands.DeleteApplicantSkill
{
    public class DeleteApplicantSkillCommand : ICommand
    {
        public Guid ApplicantId { get; set; }
        public Guid SkillId { get; set; }
    }
}
