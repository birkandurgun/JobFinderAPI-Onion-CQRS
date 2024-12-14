using JobFinderAPI.Application.Interfaces.CommandQuery;
using JobFinderAPI.Application.Interfaces.UnitOfWorks;
using JobFinderAPI.Domain.Entities;
using JobFinderAPI.Domain.Shared;

namespace JobFinderAPI.Application.Features.Employers.Commands.CreateLocation
{
    public class CreateLocationCommandHandler : ICommandHandler<CreateLocationCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateLocationCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Result> Handle(CreateLocationCommand request, CancellationToken cancellationToken)
        {
            var employer = await _unitOfWork.ReadRepository<Employer>().GetSingleAsync(e => e.Id == request.EmployerId);

            if (employer == null)
                return Result.Fail("Employer with this ID does not exist.");

            var location = new Location
            {
                EmployerId = request.EmployerId,
                Country = request.Country,
                City = request.City,
                District = request.District,
                AddressLine = request.AddressLine
            };

            await _unitOfWork.WriteRepository<Location>().AddAsync(location);

            if (await _unitOfWork.SaveAsync() == 0)
                return Result.Fail("Saving Error.");

            return Result.Ok();
        }
    }
}
