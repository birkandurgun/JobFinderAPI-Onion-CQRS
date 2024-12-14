using JobFinderAPI.Application.Interfaces.CommandQuery;
using JobFinderAPI.Application.Interfaces.UnitOfWorks;
using JobFinderAPI.Domain.Entities;
using JobFinderAPI.Domain.Shared;

namespace JobFinderAPI.Application.Features.ApplicantSkills.Commands.CreateApplicantSkill
{
    public class CreateApplicantSkillCommandHandler : ICommandHandler<CreateApplicantSkillCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateApplicantSkillCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(CreateApplicantSkillCommand request, CancellationToken cancellationToken)
        {

            var applicant = await _unitOfWork.ReadRepository<Applicant>()
                .GetSingleAsync(
                    a => a.Id == request.ApplicantId,
                    includes: a => a.ApplicantSkills,
                    enableTracking: true
                );

            if (applicant == null)
                return Result.Fail("Applicant not found.");

            var newSkills = request.SkillIds
                .Where(skillId => !applicant.ApplicantSkills.Any(a => a.SkillId == skillId))
                .Select(skillId => new ApplicantSkill
                {
                    ApplicantId = request.ApplicantId,
                    SkillId = skillId
                }).ToList();

            if (!newSkills.Any())
                return Result.Fail("No new skills to add.");

            foreach(var skill in newSkills)
                applicant.ApplicantSkills.Add(skill);

            _unitOfWork.WriteRepository<Applicant>().Update(applicant);

            if (await _unitOfWork.SaveAsync() == 0)
                return Result.Fail("Failed to add skills.");

            return Result.Ok();
        }
    }
}
