using JobFinderAPI.Application.Common;
using JobFinderAPI.Application.Interfaces.CommandQuery;
using JobFinderAPI.Application.Interfaces.UnitOfWorks;
using JobFinderAPI.Domain.Entities;
using JobFinderAPI.Domain.Shared;
using System.Linq.Expressions;

namespace JobFinderAPI.Application.Features.JobPostings.Queries.GetAllJobPostings
{
    public class GetAllJobPostingsQueryHandler : IQueryHandler<GetAllJobPostingsQuery, PaginatedResult<GetAllJobPostingsResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllJobPostingsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<PaginatedResult<GetAllJobPostingsResponse>>> Handle(GetAllJobPostingsQuery request, CancellationToken cancellationToken)
        {
            var includes = new Expression<Func<JobPosting, object>>[]
            {
                jp => jp.Employer
            };

            var jobPostings = await _unitOfWork.ReadRepository<JobPosting>()
                .GetWithPaginationAsync(
                    page: request.Page,
                    pageSize: request.PageSize,
                    includes: includes
                );

            var response = jobPostings.Data.Select(jobPosting => new GetAllJobPostingsResponse
            {
                Title = jobPosting.Title,
                Description = jobPosting.Description,
                WorkPreference = jobPosting.WorkPreference.ToString(),
                Sector = jobPosting.Sector.ToString(),
                CompanyName = jobPosting.Employer.CompanyName,
            }).ToList();

            var result = new PaginatedResult<GetAllJobPostingsResponse>
            {
                Data = response,
                TotalCount = jobPostings.TotalCount,
                Page = request.Page,
                PageSize = request.PageSize,
                TotalPages = jobPostings.TotalPages
            };

            return Result.Ok(result);
        }
    }
}
