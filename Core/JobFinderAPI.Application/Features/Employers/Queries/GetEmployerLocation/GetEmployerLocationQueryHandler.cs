using JobFinderAPI.Application.Interfaces.CommandQuery;
using JobFinderAPI.Application.Interfaces.UnitOfWorks;
using JobFinderAPI.Domain.Entities;
using JobFinderAPI.Domain.Shared;

namespace JobFinderAPI.Application.Features.Employers.Queries.GetEmployerLocation
{
    public class GetEmployerLocationQueryHandler : IQueryHandler<GetEmployerLocationQuery, GetEmployerLocationQueryResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetEmployerLocationQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Result<GetEmployerLocationQueryResponse>> Handle(GetEmployerLocationQuery request, CancellationToken cancellationToken)
        {
            var location = await _unitOfWork.ReadRepository<Location>().GetSingleAsync(l  => l.EmployerId == Guid.Parse(request.EmployerId));

            if (location == null)
                return Result.Fail<GetEmployerLocationQueryResponse>("Employer with this ID does not exist.");


            return Result.Ok(new GetEmployerLocationQueryResponse
            {
                Country = location.Country,
                City = location.City,
                District = location.District,
                AddressLine = location.AddressLine
            });
        }
    }
}
