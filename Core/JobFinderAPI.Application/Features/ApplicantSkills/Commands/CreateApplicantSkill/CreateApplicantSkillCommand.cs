using JobFinderAPI.Application.Interfaces.CommandQuery;

namespace JobFinderAPI.Application.Features.ApplicantSkills.Commands.CreateApplicantSkill
{
    public class CreateApplicantSkillCommand : ICommand
    {
        public Guid ApplicantId { get; set; }
        public List<Guid> SkillIds { get; set; }
    }
}
