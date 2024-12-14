using JobFinderAPI.Application.Interfaces.CommandQuery;
using JobFinderAPI.Application.Interfaces.UnitOfWorks;
using JobFinderAPI.Domain.Entities;
using JobFinderAPI.Domain.Shared;
using System.Linq.Expressions;

namespace JobFinderAPI.Application.Features.JobPostings.Queries.GetRequiredSkills
{
    public class GetRequiredSkillsQueryHandler : IQueryHandler<GetRequiredSkillsQuery, List<GetRequiredSkillsQueryResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetRequiredSkillsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Result<List<GetRequiredSkillsQueryResponse>>> Handle(GetRequiredSkillsQuery request, CancellationToken cancellationToken)
        {
            var includes = new Expression<Func<Skill, object>>[] { s => s.JobPostingSkills };

            var requiredSkills = _unitOfWork.ReadRepository<Skill>().GetWhere(
                predicate: s => s.JobPostingSkills.Any(jps => jps.JobPostingId == Guid.Parse(request.JobPostingId)),
                includes: includes).ToList();

            var response = requiredSkills.Select(s => new GetRequiredSkillsQueryResponse
            {
                SkillName = s.Name
            }).ToList();

            return Result.Ok(response);
        }
    }
}
