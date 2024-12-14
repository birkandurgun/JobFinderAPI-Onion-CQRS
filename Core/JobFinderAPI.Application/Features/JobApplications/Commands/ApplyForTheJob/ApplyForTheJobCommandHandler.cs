using JobFinderAPI.Application.Interfaces.CommandQuery;
using JobFinderAPI.Application.Interfaces.UnitOfWorks;
using JobFinderAPI.Domain.Entities;
using JobFinderAPI.Domain.Shared;

namespace JobFinderAPI.Application.Features.JobApplications.Commands.ApplyForTheJob
{
    public class ApplyForTheJobCommandHandler : ICommandHandler<ApplyForTheJobCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ApplyForTheJobCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(ApplyForTheJobCommand request, CancellationToken cancellationToken)
        {
            var applicant = await _unitOfWork.ReadRepository<Applicant>()
                .GetSingleAsync(a => a.Id == request.ApplicantId,
                    includes: a => a.JobApplications,
                    enableTracking: true
                    );

            if (applicant == null)
                return Result.Fail("Applicant not found.");

            var alreadyApplied = applicant.JobApplications.Any(ja => ja.JobPostingId == request.JobPostingId);

            if (alreadyApplied)
                return Result.Fail("You have already applied for this job.");

            applicant.JobApplications.Add(new JobApplication
            {
                ApplicantId = request.ApplicantId,
                JobPostingId = request.JobPostingId
            });

            _unitOfWork.WriteRepository<Applicant>().Update(applicant);

            if (await _unitOfWork.SaveAsync() == 0)
                return Result.Fail("Failed to apply for the job.");

            return Result.Ok();
        }
    }
}
