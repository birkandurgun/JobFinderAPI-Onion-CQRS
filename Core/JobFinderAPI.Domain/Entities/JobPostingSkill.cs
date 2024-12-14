using JobFinderAPI.Domain.Entities;

public class JobPostingSkill
{
    public Guid JobPostingId { get; set; }
    public JobPosting JobPosting { get; set; }

    public Guid SkillId { get; set; }
    public Skill Skill { get; set; }
}