using JobFinderAPI.Application.Interfaces.CommandQuery;
using JobFinderAPI.Application.Interfaces.UnitOfWorks;
using JobFinderAPI.Domain.Entities;
using JobFinderAPI.Domain.Shared;

namespace JobFinderAPI.Application.Features.JobPostings.Commands.UpdateJobPosting
{
    public class UpdateJobPostingCommandHandler : ICommandHandler<UpdateJobPostingCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateJobPostingCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Result> Handle(UpdateJobPostingCommand request, CancellationToken cancellationToken)
        {
            var post = await _unitOfWork.ReadRepository<JobPosting>().GetSingleAsync(jp => jp.Id == request.Id);

            if (post == null)
                return Result.Fail("Job Posting not found.");

            post.Title = request.Title;
            post.Description = request.Description;
            post.WorkPreference = request.WorkPreference;
            post.Sector = request.Sector;

            _unitOfWork.WriteRepository<JobPosting>().Update(post);

            if (await _unitOfWork.SaveAsync() == 0)
                return Result.Fail("Saving Error.");

            return Result.Ok();
        }
    }
}
