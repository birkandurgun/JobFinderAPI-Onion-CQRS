using JobFinderAPI.Domain.Entities.Common.User;

namespace JobFinderAPI.Domain.Entities
{
    public class Applicant : SystemUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Resume Resume { get; set; }
        public ICollection<Education> Educations { get; set; }
        public ICollection<Experience> Experiences { get; set; }
        public ICollection<ApplicantSkill> ApplicantSkills { get; set; }
        public ICollection<JobApplication> JobApplications { get; set; }

    }
}
