using JobFinderAPI.Domain.Entities.Common;

namespace JobFinderAPI.Domain.Entities
{
    public class Location: BaseEntity
    {
        public string District { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string AddressLine { get; set; }

        public Guid EmployerId { get; set; }
        public Employer Employer { get; set; }
    }
}
