using JobFinderAPI.Application.Interfaces.CommandQuery;
using JobFinderAPI.Application.Interfaces.UnitOfWorks;
using JobFinderAPI.Domain.Entities;
using JobFinderAPI.Domain.Shared;

namespace JobFinderAPI.Application.Features.Skills.Commands.CreateMultiSkills
{
    public class CreateMultiSkillCommandHandler : ICommandHandler<CreateMultiSkillsCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateMultiSkillCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Result> Handle(CreateMultiSkillsCommand request, CancellationToken cancellationToken)
        {
            var skills = new List<Skill>();

            foreach (var skill in request.SkillNames) {
                skills.Add(new Skill { Name = skill });
            }

            await _unitOfWork.WriteRepository<Skill>().AddRangeAsync(skills);

            if (await _unitOfWork.SaveAsync() == 0)
                return Result.Fail("Saving Error.");

            return Result.Ok();
        }
    }
}
