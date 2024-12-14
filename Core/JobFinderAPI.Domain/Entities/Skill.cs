using JobFinderAPI.Domain.Entities.Common;

namespace JobFinderAPI.Domain.Entities
{
    public class Skill: BaseEntity
    {
        public string Name { get; set; }

        public ICollection<ApplicantSkill> ApplicantSkills { get; set; }
        public ICollection<JobPostingSkill> JobPostingSkills { get; set; }
    }
}