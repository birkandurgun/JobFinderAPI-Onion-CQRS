using JobFinderAPI.Application.Interfaces.CommandQuery;
using JobFinderAPI.Application.Interfaces.UnitOfWorks;
using JobFinderAPI.Domain.Entities;
using JobFinderAPI.Domain.Shared;

namespace JobFinderAPI.Application.Features.Applicants.Queries.GetApplicantResume
{
    public class GetApplicantResumeQueryHandler : IQueryHandler<GetApplicantResumeQuery, GetApplicantResumeQueryResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetApplicantResumeQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<GetApplicantResumeQueryResponse>> Handle(GetApplicantResumeQuery request, CancellationToken cancellationToken)
        {
            var resume = await _unitOfWork.ReadRepository<Resume>()
                .GetSingleAsync(r => r.ApplicantId == request.ApplicantId, enableTracking: false);

            if (resume == null)
                return Result.Fail<GetApplicantResumeQueryResponse>("Resume not found.");

            var response = new GetApplicantResumeQueryResponse { Url = resume.Url };

            return Result.Ok(response);
        }
    }
}
