using JobFinderAPI.Application.Interfaces.CommandQuery;
using JobFinderAPI.Application.Interfaces.UnitOfWorks;
using JobFinderAPI.Domain.Entities;
using JobFinderAPI.Domain.Shared;

namespace JobFinderAPI.Application.Features.Skills.Commands.UpdateSkill
{
    public class UpdateSkillCommandHandler : ICommandHandler<UpdateSkillCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateSkillCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Result> Handle(UpdateSkillCommand request, CancellationToken cancellationToken)
        {
            var skill = await _unitOfWork.ReadRepository<Skill>().GetSingleAsync(s => s.Id == Guid.Parse(request.Id));

            if (skill == null)
                return Result.Fail("Skill with this id does not exist.");

            skill.Name = request.SkillName;
            _unitOfWork.WriteRepository<Skill>().Update(skill);

            if(await _unitOfWork.SaveAsync() == 0)
                return Result.Fail("Saving Error.");

            return Result.Ok();
        }
    }
}
