using JobFinderAPI.Application.Interfaces.CommandQuery;
using JobFinderAPI.Application.Interfaces.UnitOfWorks;
using JobFinderAPI.Domain.Entities;
using JobFinderAPI.Domain.Shared;

namespace JobFinderAPI.Application.Features.ApplicantSkills.Commands.DeleteApplicantSkill
{
    public class DeleteApplicantSkillCommandHandler : ICommandHandler<DeleteApplicantSkillCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteApplicantSkillCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(DeleteApplicantSkillCommand request, CancellationToken cancellationToken)
        {
            var applicant = await _unitOfWork.ReadRepository<Applicant>()
                .GetSingleAsync(
                    a => a.Id == request.ApplicantId,
                    includes: a => a.ApplicantSkills,
                    enableTracking: true
                );

            if (applicant == null)
                return Result.Fail("Applicant not found.");

            var applicantSkill = applicant.ApplicantSkills
                .FirstOrDefault(a => a.SkillId == request.SkillId);

            if (applicantSkill == null)
                return Result.Fail("Skill not associated with the applicant.");

            applicant.ApplicantSkills.Remove(applicantSkill);

            _unitOfWork.WriteRepository<Applicant>().Update(applicant);

            if (await _unitOfWork.SaveAsync() == 0)
                return Result.Fail("Failed to delete the skill.");

            return Result.Ok();
        }
    }
}
