namespace JobFinderAPI.Application.Features.JobPostings.Queries.GetJobPostingById
{
    public class GetJobPostingByIdQueryResponse
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string WorkPreference { get; set; }
        public string Sector { get; set; }
        public string CompanyName { get; set; }
    }
}