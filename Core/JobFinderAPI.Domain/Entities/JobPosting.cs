using JobFinderAPI.Domain.Entities.Common;
using JobFinderAPI.Domain.Enums;

namespace JobFinderAPI.Domain.Entities
{
    public class JobPosting: BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public WorkPreference WorkPreference { get; set; }
        public Sector Sector { get; set; }


        public Guid EmployerId { get; set; }
        public Employer Employer { get; set; }

        public ICollection<JobApplication> JobApplications { get; set; }
        public ICollection<JobPostingSkill> RequiredSkills { get; set; }

    }
}
