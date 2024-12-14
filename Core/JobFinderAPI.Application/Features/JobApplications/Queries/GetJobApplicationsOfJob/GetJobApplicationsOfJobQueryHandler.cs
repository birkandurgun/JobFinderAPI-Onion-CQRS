using JobFinderAPI.Application.Interfaces.CommandQuery;
using JobFinderAPI.Application.Interfaces.UnitOfWorks;
using JobFinderAPI.Domain.Entities;
using JobFinderAPI.Domain.Shared;

namespace JobFinderAPI.Application.Features.JobApplications.Queries.GetJobApplicationsOfJob
{
    public class GetJobApplicationsOfJobQueryHandler : IQueryHandler<GetJobApplicationsOfJobQuery, List<GetJobApplicationsOfJobQueryResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetJobApplicationsOfJobQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<List<GetJobApplicationsOfJobQueryResponse>>> Handle(GetJobApplicationsOfJobQuery request, CancellationToken cancellationToken)
        {
            var jobPosting = await _unitOfWork.ReadRepository<JobPosting>()
                .GetSingleAsync(
                    j => j.Id == request.JobPostingId,
                    includes: j => j.JobApplications
                );

            if (jobPosting == null || !jobPosting.JobApplications.Any())
                return Result.Fail<List<GetJobApplicationsOfJobQueryResponse>>("No applications found for this job posting.");

            var applicantIds = jobPosting.JobApplications.Select(ja => ja.ApplicantId).Distinct().ToList();

            var applicants = _unitOfWork.ReadRepository<Applicant>()
                .GetWhere(a => applicantIds.Contains(a.Id))
                .ToList();

            var response = new List<GetJobApplicationsOfJobQueryResponse>();

            foreach (var jobApplication in jobPosting.JobApplications)
            {
                var applicant = applicants.FirstOrDefault(a => a.Id == jobApplication.ApplicantId);
                if (applicant != null)
                {
                    response.Add(new GetJobApplicationsOfJobQueryResponse
                    {
                        ApplicantFirstName = applicant.FirstName,
                        ApplicantLastName = applicant.LastName
                    });
                }
            }

            return Result.Ok(response);
        }
    }
}
