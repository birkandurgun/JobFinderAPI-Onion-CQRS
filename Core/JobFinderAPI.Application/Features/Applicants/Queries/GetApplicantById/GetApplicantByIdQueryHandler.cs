using JobFinderAPI.Application.Interfaces.CommandQuery;
using JobFinderAPI.Application.Interfaces.UnitOfWorks;
using JobFinderAPI.Domain.Entities;
using JobFinderAPI.Domain.Shared;

namespace JobFinderAPI.Application.Features.Applicants.Queries.GetApplicantById
{
    public class GetApplicantByIdQueryHandler : IQueryHandler<GetApplicantByIdQuery, GetApplicantByIdResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetApplicantByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<GetApplicantByIdResponse>> Handle(GetApplicantByIdQuery request, CancellationToken cancellationToken)
        {
            var applicant = await _unitOfWork.ReadRepository<Applicant>().GetByIdAsync(request.Id);

            if (applicant == null)
                return Result.Fail<GetApplicantByIdResponse>("Applicant not found.");

            return Result.Ok(new GetApplicantByIdResponse
            {
                FirstName = applicant.FirstName,
                LastName = applicant.LastName,
                Email = applicant.Email,
                PhoneNumber = applicant.CountryCode + applicant.PhoneNumber
            });
        }
    }
}
