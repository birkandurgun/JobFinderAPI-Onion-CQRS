using JobFinderAPI.Application.Interfaces.CommandQuery;
using JobFinderAPI.Application.Interfaces.UnitOfWorks;
using JobFinderAPI.Domain.Entities;
using JobFinderAPI.Domain.Shared;

namespace JobFinderAPI.Application.Features.Applicants.Commands.UpdateExperience
{
    public class UpdateExperienceCommandHandler : ICommandHandler<UpdateExperienceCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateExperienceCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(UpdateExperienceCommand request, CancellationToken cancellationToken)
        {
            var experience = await _unitOfWork.ReadRepository<Experience>().GetByIdAsync(request.Id.ToString());

            if (experience == null)
                return Result.Fail("Experience not found.");

            experience.StartDate = request.StartDate;
            experience.EndDate = request.EndDate;
            experience.Description = request.Description;
            experience.Company = request.Company;
            experience.Title = request.Title;

            _unitOfWork.WriteRepository<Experience>().Update(experience);

            if (await _unitOfWork.SaveAsync() == 0)
                return Result.Fail("Saving error.");

            return Result.Ok();
        }
    }
}
