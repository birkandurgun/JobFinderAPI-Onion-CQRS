using JobFinderAPI.Application.Interfaces.CommandQuery;
using JobFinderAPI.Application.Interfaces.UnitOfWorks;
using JobFinderAPI.Domain.Entities;
using JobFinderAPI.Domain.Shared;

namespace JobFinderAPI.Application.Features.Applicants.Queries.GetApplicantEducations
{
    public class GetApplicantEducationsQueryHandler : IQueryHandler<GetApplicantEducationsQuery, List<GetApplicantEducationsQueryResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetApplicantEducationsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<List<GetApplicantEducationsQueryResponse>>> Handle(GetApplicantEducationsQuery request, CancellationToken cancellationToken)
        {
            var educations = _unitOfWork.ReadRepository<Education>()
                .GetWhere(e => e.ApplicantId == request.ApplicantId)
                .Select(e => new GetApplicantEducationsQueryResponse
                {
                    Institution = e.Institution,
                    Field = e.Field,
                    StartDate = e.StartDate,
                    EndDate = e.EndDate
                })
                .ToList();

            return Result.Ok(educations);
        }
    }
}
