using JobFinderAPI.Application.Interfaces.CommandQuery;
using JobFinderAPI.Application.Interfaces.UnitOfWorks;
using JobFinderAPI.Domain.Entities;
using JobFinderAPI.Domain.Shared;

namespace JobFinderAPI.Application.Features.Employers.Commands.UpdateLocation
{
    public class UpdateLocationCommandHandler : ICommandHandler<UpdateLocationCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateLocationCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Result> Handle(UpdateLocationCommand request, CancellationToken cancellationToken)
        {
            var location = await _unitOfWork.ReadRepository<Location>().GetSingleAsync(l => l.EmployerId == request.EmployerId);

            if (location == null)
                return Result.Fail("Employer with this id does not exist.");

            location.Country = request.Country;
            location.City = request.City;
            location.District = request.District;
            location.AddressLine = request.AddressLine;

            _unitOfWork.WriteRepository<Location>().Update(location);

            if (await _unitOfWork.SaveAsync() == 0)
                return Result.Fail("Saving Error.");

            return Result.Ok();
        }
    }
}
