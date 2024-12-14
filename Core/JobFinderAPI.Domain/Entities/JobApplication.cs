using JobFinderAPI.Domain.Entities.Common;

namespace JobFinderAPI.Domain.Entities
{
    public class JobApplication
    {
        public Guid ApplicantId { get; set; }
        public Applicant Applicant { get; set; }

        public Guid JobPostingId { get; set; }
        public JobPosting JobPosting { get; set; }
    }
}
