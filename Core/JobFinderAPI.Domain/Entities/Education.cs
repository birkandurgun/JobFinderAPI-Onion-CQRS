using JobFinderAPI.Domain.Entities.Common;

namespace JobFinderAPI.Domain.Entities
{
    public class Education: BaseEntity
    {
        public string Institution { get; set; }
        public string Field { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public Guid ApplicantId { get; set; }
        public Applicant Applicant { get; set; }

    }
}
