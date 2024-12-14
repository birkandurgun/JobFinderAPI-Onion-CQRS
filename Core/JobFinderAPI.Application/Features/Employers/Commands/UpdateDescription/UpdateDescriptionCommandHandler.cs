using JobFinderAPI.Application.Interfaces.CommandQuery;
using JobFinderAPI.Application.Interfaces.UnitOfWorks;
using JobFinderAPI.Domain.Entities;
using JobFinderAPI.Domain.Shared;

namespace JobFinderAPI.Application.Features.Employers.Commands.UpdateDescription
{
    public class UpdateDescriptionCommandHandler : ICommandHandler<UpdateDescriptionCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateDescriptionCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Result> Handle(UpdateDescriptionCommand request, CancellationToken cancellationToken)
        {
            var employer = await _unitOfWork.ReadRepository<Employer>().GetSingleAsync(e => e.Id == request.Id);

            if (employer == null)
                return Result.Fail("Employer not found.");

            employer.Description = request.Description;
            _unitOfWork.WriteRepository<Employer>().Update(employer);

            if (await _unitOfWork.SaveAsync() == 0)
                return Result.Fail("Saving Error.");

            return Result.Ok();
        }
    }
}
