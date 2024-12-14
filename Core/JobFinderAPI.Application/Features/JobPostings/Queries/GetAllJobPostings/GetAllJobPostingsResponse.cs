using JobFinderAPI.Domain.Entities;

namespace JobFinderAPI.Application.Features.JobPostings.Queries.GetAllJobPostings
{
    public class GetAllJobPostingsResponse
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string WorkPreference { get; set; }
        public string Sector { get; set; }
        public string CompanyName { get; set; }
    }
}