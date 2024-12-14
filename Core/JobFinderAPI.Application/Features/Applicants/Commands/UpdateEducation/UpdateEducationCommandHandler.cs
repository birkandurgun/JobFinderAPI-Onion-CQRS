using JobFinderAPI.Application.Interfaces.CommandQuery;
using JobFinderAPI.Application.Interfaces.UnitOfWorks;
using JobFinderAPI.Domain.Entities;
using JobFinderAPI.Domain.Shared;

namespace JobFinderAPI.Application.Features.Applicants.Commands.UpdateEducation
{
    public class UpdateEducationCommandHandler : ICommandHandler<UpdateEducationCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateEducationCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Result> Handle(UpdateEducationCommand request, CancellationToken cancellationToken)
        {
            var education = await _unitOfWork.ReadRepository<Education>().GetByIdAsync(request.Id.ToString());

            if (education == null)
                return Result.Fail("Education not found.");

            education.StartDate = request.StartDate;
            education.EndDate = request.EndDate;
            education.Institution = request.Institution;
            education.Field = request.Field;

            _unitOfWork.WriteRepository<Education>().Update(education);

            if (await _unitOfWork.SaveAsync() == 0)
                return Result.Fail("Saving error.");

            return Result.Ok();
        }
    }
}
