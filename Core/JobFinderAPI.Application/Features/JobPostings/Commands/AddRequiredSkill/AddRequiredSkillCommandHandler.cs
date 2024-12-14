using JobFinderAPI.Application.Interfaces.CommandQuery;
using JobFinderAPI.Application.Interfaces.UnitOfWorks;
using JobFinderAPI.Domain.Entities;
using JobFinderAPI.Domain.Shared;

namespace JobFinderAPI.Application.Features.JobPostings.Commands.AddRequiredSkill
{
    public class AddRequiredSkillCommandHandler : ICommandHandler<AddRequiredSkillCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AddRequiredSkillCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Result> Handle(AddRequiredSkillCommand request, CancellationToken cancellationToken)
        {
            var jobPosting = await _unitOfWork.ReadRepository<JobPosting>().GetByIdAsync(
            request.JobPostingId.ToString(),
            enableTracking: true,
            includes: jp => jp.RequiredSkills);

            if (jobPosting == null)
                return Result.Fail("Job Posting not found.");

            var skillExists = await _unitOfWork.ReadRepository<Skill>().GetByIdAsync(request.SkillId.ToString());
            if (skillExists == null)
                return Result.Fail("Skill not found.");

            var skillAlreadyExists = jobPosting.RequiredSkills.Any(s => s.SkillId == request.SkillId);
            if (skillAlreadyExists)
                return Result.Fail("Skill already exists in job posting.");

            jobPosting.RequiredSkills.Add(new JobPostingSkill
            {
                JobPostingId = request.JobPostingId,
                SkillId = request.SkillId
            });

            _unitOfWork.WriteRepository<JobPosting>().Update(jobPosting);

            if (await _unitOfWork.SaveAsync() == 0)
                return Result.Fail("Saving Error.");

            return Result.Ok();
        }
    }
}
