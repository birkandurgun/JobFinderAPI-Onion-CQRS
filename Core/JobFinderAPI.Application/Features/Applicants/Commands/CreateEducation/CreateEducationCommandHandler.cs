using JobFinderAPI.Application.Interfaces.CommandQuery;
using JobFinderAPI.Application.Interfaces.UnitOfWorks;
using JobFinderAPI.Domain.Entities;
using JobFinderAPI.Domain.Shared;

namespace JobFinderAPI.Application.Features.Applicants.Commands.CreateEducation
{
    public class CreateEducationCommandHandler : ICommandHandler<CreateEducationCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateEducationCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Result> Handle(CreateEducationCommand request, CancellationToken cancellationToken)
        {
            var applicant = await _unitOfWork.ReadRepository<Applicant>().GetByIdAsync(request.ApplicantId.ToString());

            if (applicant == null)
                return Result.Fail("Applicant not found.");

            await _unitOfWork.WriteRepository<Education>().AddAsync(new Education
            {
                Institution = request.Institution,
                Field = request.Field,
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
