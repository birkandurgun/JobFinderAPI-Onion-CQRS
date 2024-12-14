using JobFinderAPI.Application.Common;
using JobFinderAPI.Application.Interfaces.CommandQuery;

namespace JobFinderAPI.Application.Features.JobPostings.Queries.GetAllJobPostings
{
    public class GetAllJobPostingsQuery : IQuery<PaginatedResult<GetAllJobPostingsResponse>>
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
