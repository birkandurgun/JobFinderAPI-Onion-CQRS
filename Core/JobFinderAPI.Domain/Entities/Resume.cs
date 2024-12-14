using JobFinderAPI.Domain.Entities.Common;

namespace JobFinderAPI.Domain.Entities
{
    public class Resume: BaseEntity
    {
        public string Url { get; set; }

        public Guid ApplicantId { get; set; }
        public Applicant Applicant { get; set; }
    }
}
