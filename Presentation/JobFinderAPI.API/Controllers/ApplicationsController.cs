using JobFinderAPI.Application.Features.JobApplications.Commands.ApplyForTheJob;
using JobFinderAPI.Application.Features.JobApplications.Queries.GetJobApplicationsOfJob;
using JobFinderAPI.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobFinderAPI.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ApplicationsController : ApiController
    {
        private readonly ISender _sender;

        public ApplicationsController(ISender sender) : base(sender) => _sender = sender;

        [HttpPost]
        [Authorize(Roles = nameof(Role.Applicant))]
        public async Task<IActionResult> Apply([FromBody] ApplyForTheJobCommand command)
        {
            var result = await _sender.Send(command);
            return result.IsSuccess
                ? Ok(result)
                : HandleFailure(result);
        }

        [HttpGet]
        [Route("{jobPostingId}")]
        [Authorize(Roles = nameof(Role.Employer))]
        public async Task<IActionResult> GetJobApplicationsOfJob([FromRoute] Guid jobPostingId)
        {
            var result = await _sender.Send(new GetJobApplicationsOfJobQuery { JobPostingId = jobPostingId });
            return result.IsSuccess
                ? Ok(result)
                : HandleFailure(result);
        }
    }
}
