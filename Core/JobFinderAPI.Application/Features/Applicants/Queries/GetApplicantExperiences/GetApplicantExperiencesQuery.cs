using JobFinderAPI.Application.Interfaces.CommandQuery;

namespace JobFinderAPI.Application.Features.Applicants.Queries.GetApplicantExperiences
{
    public class GetApplicantExperiencesQuery : IQuery<List<GetApplicantExperiencesQueryResponse>>
    {
        public Guid ApplicantId { get; set; }
    }
}
