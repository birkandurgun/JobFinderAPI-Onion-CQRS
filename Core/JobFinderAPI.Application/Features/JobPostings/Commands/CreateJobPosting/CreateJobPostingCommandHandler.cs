using JobFinderAPI.Application.Interfaces.CommandQuery;
using JobFinderAPI.Application.Interfaces.UnitOfWorks;
using JobFinderAPI.Domain.Entities;
using JobFinderAPI.Domain.Shared;

namespace JobFinderAPI.Application.Features.JobPostings.Commands.CreateJobPosting
{
    public class CreateJobPostingCommandHandler : ICommandHandler<CreateJobPostingCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateJobPostingCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(CreateJobPostingCommand request, CancellationToken cancellationToken)
        {
            var employer = await _unitOfWork.ReadRepository<Employer>()
                            .GetByIdAsync(request.EmployerId.ToString());

            if (employer == null)
                return Result.Fail("Employer not found");

            var skills = _unitOfWork.ReadRepository<Skill>()
                                    .GetWhere(s => request.RequiredSkillIds.Contains(s.Id)).ToList();

            if (skills.Count != request.RequiredSkillIds.Count)
                return Result.Fail("One or more skills do not exist");

            var jobPosting = new JobPosting
            {
                Title = request.Title,
                Description = request.Description,
                EmployerId = request.EmployerId,
                WorkPreference = request.WorkPreference,
                Sector = request.Sector,
                RequiredSkills = request.RequiredSkillIds.Select(skillId => new JobPostingSkill
                {
                    SkillId = skillId
                }).ToList()
            };

            await _unitOfWork.WriteRepository<JobPosting>().AddAsync(jobPosting);

            if (await _unitOfWork.SaveAsync() == 0)
                return Result.Fail("Saving Error.");

            return Result.Ok();
        }
    }
}
