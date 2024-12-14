using JobFinderAPI.Domain.Entities.Common;
using JobFinderAPI.Domain.Entities.Common.User;

namespace JobFinderAPI.Domain.Entities
{
    public class Employer: SystemUser
    {
        public string CompanyName { get; set; }
        public string? Description { get; set; }

        public Location Location { get; set; }
        public ICollection<JobPosting> JobPostings { get; set; }

    }
}
