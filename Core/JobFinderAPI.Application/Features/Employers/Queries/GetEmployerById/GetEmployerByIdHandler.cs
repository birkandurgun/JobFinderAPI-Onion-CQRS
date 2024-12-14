using JobFinderAPI.Application.Interfaces.CommandQuery;
using JobFinderAPI.Application.Interfaces.UnitOfWorks;
using JobFinderAPI.Domain.Entities;
using JobFinderAPI.Domain.Shared;

namespace JobFinderAPI.Application.Features.Employers.Queries.GetEmployerById
{
    public class GetEmployerByIdHandler : IQueryHandler<GetEmployerByIdQuery, GetEmployerByIdResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetEmployerByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Result<GetEmployerByIdResponse>> Handle(GetEmployerByIdQuery request, CancellationToken cancellationToken)
        {
            var employer = await _unitOfWork.ReadRepository<Employer>()
                                    .GetByIdAsync(request.Id);

            if (employer is null)
                return Result.Fail<GetEmployerByIdResponse>("Employer with this ID does not exist.");

            return Result.Ok(new GetEmployerByIdResponse()
            {
                CompanyName = employer.CompanyName,
                Description = employer.Description,
                Email = employer.Email,
                PhoneNumber = employer.PhoneNumber
            });
        }
    }
}
