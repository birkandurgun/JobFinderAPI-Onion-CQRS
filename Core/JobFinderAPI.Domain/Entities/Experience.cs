using JobFinderAPI.Domain.Entities.Common;

namespace JobFinderAPI.Domain.Entities
{
    public class Experience: BaseEntity
    {
        public string Title { get; set; }
        public string Company { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Description { get; set; }

        public Guid ApplicantId { get; set; }
        public Applicant Applicant { get; set; }
    }
}
