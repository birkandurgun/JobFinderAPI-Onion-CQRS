using JobFinderAPI.Application.Interfaces.CommandQuery;

namespace JobFinderAPI.Application.Features.JobPostings.Queries.GetJobPostingById
{
    public class GetJobPostingByIdQuery : IQuery<GetJobPostingByIdQueryResponse>
    {
        public string Id { get; set; }
    }
}
