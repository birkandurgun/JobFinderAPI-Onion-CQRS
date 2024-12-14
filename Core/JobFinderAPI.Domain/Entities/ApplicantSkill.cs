using JobFinderAPI.Domain.Entities;

public class ApplicantSkill
{
    public Guid ApplicantId { get; set; }
    public Applicant Applicant { get; set; }

    public Guid SkillId { get; set; }
    public Skill Skill { get; set; }
}