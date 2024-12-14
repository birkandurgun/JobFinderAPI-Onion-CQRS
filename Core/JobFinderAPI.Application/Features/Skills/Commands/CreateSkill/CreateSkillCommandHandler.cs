using JobFinderAPI.Application.Interfaces.CommandQuery;
using JobFinderAPI.Application.Interfaces.UnitOfWorks;
using JobFinderAPI.Domain.Entities;
using JobFinderAPI.Domain.Shared;

namespace JobFinderAPI.Application.Features.Skills.Commands.CreateSkill
{
    public class CreateSkillCommandHandler : ICommandHandler<CreateSkillCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateSkillCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Result> Handle(CreateSkillCommand request, CancellationToken cancellationToken)
        {
            var skill = new Skill { Name = request.Name };

            await _unitOfWork.WriteRepository<Skill>().AddAsync(skill);

            if (await _unitOfWork.SaveAsync() == 0)
                return Result.Fail("Saving Error.");

            return Result.Ok();
        }
    }
}
