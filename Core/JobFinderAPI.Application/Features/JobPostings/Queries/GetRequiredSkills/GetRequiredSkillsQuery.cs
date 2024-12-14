using JobFinderAPI.Application.Interfaces.CommandQuery;

namespace JobFinderAPI.Application.Features.JobPostings.Queries.GetRequiredSkills
{
    public class GetRequiredSkillsQuery: IQuery<List<GetRequiredSkillsQueryResponse>>
    {
        public string JobPostingId { get; set; }
    }
}
