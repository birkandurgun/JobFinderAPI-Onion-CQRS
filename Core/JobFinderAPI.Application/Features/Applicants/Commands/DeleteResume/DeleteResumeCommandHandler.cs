using JobFinderAPI.Application.Interfaces.CommandQuery;
using JobFinderAPI.Application.Interfaces.UnitOfWorks;
using JobFinderAPI.Domain.Entities;
using JobFinderAPI.Domain.Shared;

namespace JobFinderAPI.Application.Features.Applicants.Commands.DeleteResume
{
    public class DeleteResumeCommandHandler : ICommandHandler<DeleteResumeCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteResumeCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(DeleteResumeCommand request, CancellationToken cancellationToken)
        {
            var resume = await _unitOfWork.ReadRepository<Resume>().GetSingleAsync(r => r.ApplicantId == request.ApplicantId, includes: a => a.Applicant);

            if (resume == null)
                return Result.Fail("Resume not found.");

            _unitOfWork.WriteRepository<Resume>().Delete(resume);

            if (await _unitOfWork.SaveAsync() == 0)
                return Result.Fail("Failed to delete the resume.");

            return Result.Ok();
        }
    }
}
