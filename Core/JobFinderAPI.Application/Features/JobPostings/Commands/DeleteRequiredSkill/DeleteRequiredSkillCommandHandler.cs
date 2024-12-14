using JobFinderAPI.Application.Interfaces.CommandQuery;
using JobFinderAPI.Application.Interfaces.UnitOfWorks;
using JobFinderAPI.Domain.Entities;
using JobFinderAPI.Domain.Shared;

namespace JobFinderAPI.Application.Features.JobPostings.Commands.DeleteRequiredSkill
{
    public class DeleteRequiredSkillCommandHandler : ICommandHandler<DeleteRequiredSkillCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteRequiredSkillCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Result> Handle(DeleteRequiredSkillCommand request, CancellationToken cancellationToken)
        {
            var jobPosting = await _unitOfWork.ReadRepository<JobPosting>().GetByIdAsync(
            request.JobPostingId.ToString(),
            enableTracking: true,
            includes: jp => jp.RequiredSkills);

            if (jobPosting == null)
                return Result.Fail("Job Posting not found.");

            var skillToRemove = jobPosting.RequiredSkills
            .FirstOrDefault(s => s.SkillId == request.SkillId);

            if (skillToRemove == null)
                return Result.Fail("Job Posting Skill not found.");

            jobPosting.RequiredSkills.Remove(skillToRemove);
            _unitOfWork.WriteRepository<JobPosting>().Update(jobPosting);

            if (await _unitOfWork.SaveAsync() == 0)
                return Result.Fail("Saving Error.");

            return Result.Ok();
        }
    }
}
