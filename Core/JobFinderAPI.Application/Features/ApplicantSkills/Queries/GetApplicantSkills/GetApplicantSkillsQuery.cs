using JobFinderAPI.Application.Interfaces.CommandQuery;

namespace JobFinderAPI.Application.Features.ApplicantSkills.Queries.GetApplicantSkills
{
    public class GetApplicantSkillsQuery : IQuery<List<GetApplicantSkillsQueryResponse>>
    {
        public Guid ApplicantId { get; set; }
    }
}
