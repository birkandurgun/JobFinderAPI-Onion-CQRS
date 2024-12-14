using JobFinderAPI.Application.Interfaces.CommandQuery;
using JobFinderAPI.Application.Interfaces.UnitOfWorks;
using JobFinderAPI.Domain.Entities;
using JobFinderAPI.Domain.Shared;
using System.Linq.Expressions;

namespace JobFinderAPI.Application.Features.JobPostings.Queries.GetJobPostingById
{
    public class GetJobPostingByIdQueryHandler : IQueryHandler<GetJobPostingByIdQuery, GetJobPostingByIdQueryResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetJobPostingByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Result<GetJobPostingByIdQueryResponse>> Handle(GetJobPostingByIdQuery request, CancellationToken cancellationToken)
        {
            var jobPosting = await _unitOfWork.ReadRepository<JobPosting>()
                .GetByIdAsync(request.Id, includes: jp => jp.Employer);

            if (jobPosting == null)
                return Result.Fail<GetJobPostingByIdQueryResponse>("Job Posting not found.");

            var response = new GetJobPostingByIdQueryResponse
            {
                Title = jobPosting.Title,
                Description = jobPosting.Description,
                WorkPreference = jobPosting.WorkPreference.ToString(),
                Sector = jobPosting.Sector.ToString(),
                CompanyName = jobPosting.Employer?.CompanyName
            };

            return Result.Ok(response);
        }
    }
}
