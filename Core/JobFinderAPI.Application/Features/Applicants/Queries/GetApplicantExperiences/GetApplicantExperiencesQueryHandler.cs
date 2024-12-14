using JobFinderAPI.Application.Interfaces.CommandQuery;
using JobFinderAPI.Application.Interfaces.UnitOfWorks;
using JobFinderAPI.Domain.Entities;
using JobFinderAPI.Domain.Shared;

namespace JobFinderAPI.Application.Features.Applicants.Queries.GetApplicantExperiences
{
    public class GetApplicantExperiencesQueryHandler : IQueryHandler<GetApplicantExperiencesQuery, List<GetApplicantExperiencesQueryResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetApplicantExperiencesQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<List<GetApplicantExperiencesQueryResponse>>> Handle(GetApplicantExperiencesQuery request, CancellationToken cancellationToken)
        {
            var experiences = _unitOfWork.ReadRepository<Experience>()
                .GetWhere(e => e.ApplicantId == request.ApplicantId, enableTracking: false)
                .Select(e => new GetApplicantExperiencesQueryResponse
                {
                    Title = e.Title,
                    Company = e.Company,
                    Description = e.Description,
                    StartDate = e.StartDate,
                    EndDate = e.EndDate
                })
                .ToList();

            return Result.Ok(experiences);
        }
    }
}
