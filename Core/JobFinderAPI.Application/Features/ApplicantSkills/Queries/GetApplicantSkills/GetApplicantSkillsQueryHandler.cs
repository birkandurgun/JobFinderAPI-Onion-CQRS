using JobFinderAPI.Application.Interfaces.CommandQuery;
using JobFinderAPI.Application.Interfaces.UnitOfWorks;
using JobFinderAPI.Domain.Entities;
using JobFinderAPI.Domain.Shared;

namespace JobFinderAPI.Application.Features.ApplicantSkills.Queries.GetApplicantSkills
{
    public class GetApplicantSkillsQueryHandler : IQueryHandler<GetApplicantSkillsQuery, List<GetApplicantSkillsQueryResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetApplicantSkillsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<List<GetApplicantSkillsQueryResponse>>> Handle(GetApplicantSkillsQuery request, CancellationToken cancellationToken)
        {
            var skills = _unitOfWork.ReadRepository<Skill>()
                .GetWhere(
                    a => a.ApplicantSkills.Any(a => a.ApplicantId == request.ApplicantId),
                    includes: a => a.ApplicantSkills
                );

            if (!skills.Any())
                return Result.Fail<List<GetApplicantSkillsQueryResponse>>("No skills found for the applicant.");

            var response = skills.SelectMany(skill => skill.ApplicantSkills
                .Select(a => new GetApplicantSkillsQueryResponse { SkillName = skill.Name }))
                .ToList();

            return Result.Ok(response);
        }
    }
}
