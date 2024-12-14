using JobFinderAPI.Application.Interfaces.CommandQuery;
using JobFinderAPI.Application.Interfaces.UnitOfWorks;
using JobFinderAPI.Domain.Entities;
using JobFinderAPI.Domain.Shared;

namespace JobFinderAPI.Application.Features.Applicants.Commands.CreateResume
{
    public class CreateResumeCommandHandler : ICommandHandler<CreateResumeCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateResumeCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Result> Handle(CreateResumeCommand request, CancellationToken cancellationToken)
        {
            var applicant = await _unitOfWork.ReadRepository<Applicant>()
            .GetByIdAsync(request.ApplicantId.ToString());

            if (applicant == null)
                return Result.Fail("Applicant not found.");

            await _unitOfWork.WriteRepository<Resume>().AddAsync(new Resume { Url = request.Url, ApplicantId = request.ApplicantId });

            if (await _unitOfWork.SaveAsync() == 0)
                return Result.Fail("Saving error.");

            return Result.Ok();
        }
    }
}
