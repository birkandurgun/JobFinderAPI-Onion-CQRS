using JobFinderAPI.Application.Interfaces.CommandQuery;
using JobFinderAPI.Application.Interfaces.UnitOfWorks;
using JobFinderAPI.Domain.Entities;
using JobFinderAPI.Domain.Shared;

namespace JobFinderAPI.Application.Features.Applicants.Commands.CreateExperience
{
    public class CreateExperienceCommandHandler : ICommandHandler<CreateExperienceCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateExperienceCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Result> Handle(CreateExperienceCommand request, CancellationToken cancellationToken)
        {
            var applicant = await _unitOfWork.ReadRepository<Applicant>().GetByIdAsync(request.ApplicantId.ToString());

            if (applicant == null)
                return Result.Fail("Applicant not found.");

            await _unitOfWork.WriteRepository<Experience>().AddAsync(new Experience
            {
                Title = request.Title,
                Company = request.Company,
                Description = request.Description,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                ApplicantId = request.ApplicantId
            });

            if (await _unitOfWork.SaveAsync() == 0)
                return Result.Fail("Saving error.");

            return Result.Ok();
        }
    }
}
