using JobFinderAPI.Application.Interfaces.CommandQuery;

namespace JobFinderAPI.Application.Features.Applicants.Queries.GetApplicantEducations
{
    public class GetApplicantEducationsQuery : IQuery<List<GetApplicantEducationsQueryResponse>>
    {
        public Guid ApplicantId { get; set; }
    }
}
