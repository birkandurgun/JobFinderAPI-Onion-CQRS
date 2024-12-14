using JobFinderAPI.Application.Interfaces.CommandQuery;

namespace JobFinderAPI.Application.Features.JobApplications.Queries.GetJobApplicationsOfJob
{
    public class GetJobApplicationsOfJobQuery : IQuery<List<GetJobApplicationsOfJobQueryResponse>>
    {
        public Guid JobPostingId { get; set; }
    }
}
