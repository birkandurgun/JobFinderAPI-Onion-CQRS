using JobFinderAPI.Application.Interfaces.CommandQuery;

namespace JobFinderAPI.Application.Features.Applicants.Queries.GetApplicantResume
{
    public class GetApplicantResumeQuery : IQuery<GetApplicantResumeQueryResponse>
    {
        public Guid ApplicantId { get; set; }
    }
}
