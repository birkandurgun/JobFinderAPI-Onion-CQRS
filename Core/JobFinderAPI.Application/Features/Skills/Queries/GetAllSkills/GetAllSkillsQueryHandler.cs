using JobFinderAPI.Application.Interfaces.CommandQuery;
using JobFinderAPI.Application.Interfaces.UnitOfWorks;
using JobFinderAPI.Domain.Entities;
using JobFinderAPI.Domain.Shared;

namespace JobFinderAPI.Application.Features.Skills.Queries.GetAllSkills
{
    public class GetAllSkillsQueryHandler : IQueryHandler<GetAllSkillsQuery, List<GetAllSkillsQueryResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetAllSkillsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<List<GetAllSkillsQueryResponse>>> Handle(GetAllSkillsQuery request, CancellationToken cancellationToken)
        {
            var skills = _unitOfWork.ReadRepository<Skill>().GetAll().ToList();

            if (!skills.Any() || skills == null)
                return Result.Fail<List<GetAllSkillsQueryResponse>>("There is no skill.");

            var skillResponse = new List<GetAllSkillsQueryResponse>();

            foreach(var skill in skills)
                skillResponse.Add(new GetAllSkillsQueryResponse { SkillName = skill.Name });

            return Result.Ok(skillResponse);
        }
    }
}
