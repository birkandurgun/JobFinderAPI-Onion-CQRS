using JobFinderAPI.Application.Features.JobPostings.Commands.AddRequiredSkill;
using JobFinderAPI.Application.Features.JobPostings.Commands.CreateJobPosting;
using JobFinderAPI.Application.Features.JobPostings.Commands.DeleteRequiredSkill;
using JobFinderAPI.Application.Features.JobPostings.Commands.UpdateJobPosting;
using JobFinderAPI.Application.Features.JobPostings.Queries.GetAllJobPostings;
using JobFinderAPI.Application.Features.JobPostings.Queries.GetJobPostingById;
using JobFinderAPI.Application.Features.JobPostings.Queries.GetRequiredSkills;
using JobFinderAPI.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobFinderAPI.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class JobPostingsController : ApiController
    {
        private readonly ISender _sender;

        public JobPostingsController(ISender sender):base(sender)
            => _sender = sender;

        [HttpPost]
        [Authorize(Roles = nameof(Role.Employer))]
        public async Task<IActionResult> CreateJobPosting([FromBody] CreateJobPostingCommand command)
        {
            var result = await _sender.Send(command);
            return result.IsSuccess
                ? Ok(result)
                : HandleFailure(result);
        }

        [HttpPut]
        [Authorize(Roles = nameof(Role.Employer))]
        public async Task<IActionResult> UpdateJobPosting([FromBody] UpdateJobPostingCommand command)
        {
            var result = await _sender.Send(command);
            return result.IsSuccess
                ? Ok(result)
                : HandleFailure(result);
        }

        [HttpDelete]
        [Authorize(Roles = nameof(Role.Employer))]
        public async Task<IActionResult> DeleteRequiredSkill([FromQuery] Guid jobPostingId, [FromQuery] Guid skillId)
        {
            var result = await _sender.Send(new DeleteRequiredSkillCommand { JobPostingId = jobPostingId, SkillId = skillId });
            return result.IsSuccess
                ? Ok(result)
                : HandleFailure(result);
        }

        [HttpPost]
        [Authorize(Roles = nameof(Role.Employer))]
        public async Task<IActionResult> AddRequiredSkill([FromBody] AddRequiredSkillCommand command)
        {
            var result = await _sender.Send(command);
            return result.IsSuccess
                ? Ok(result)
                : HandleFailure(result);
        }

        [HttpGet]
        [Authorize(Roles = $"{nameof(Role.Admin)},{nameof(Role.Applicant)}")]
        public async Task<IActionResult> GetAllJobPostings([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var result = await _sender.Send(new GetAllJobPostingsQuery { Page = page, PageSize = pageSize });
            return result.IsSuccess
                ? Ok(result)
                : HandleFailure(result);
        }

        [HttpGet]
        [Route("{jobPostingId}")]
        [Authorize(Roles = $"{nameof(Role.Admin)},{nameof(Role.Employer)},{nameof(Role.Applicant)}")]
        public async Task<IActionResult> GetRequiredSkills([FromRoute] string jobPostingId)
        {
            var result = await _sender.Send(new GetRequiredSkillsQuery { JobPostingId = jobPostingId });
            return result.IsSuccess
                ? Ok(result)
                : HandleFailure(result);
        }

        [HttpGet]
        [Route("{id}")]
        [Authorize(Roles = $"{nameof(Role.Admin)},{nameof(Role.Employer)},{nameof(Role.Applicant)}")]
        public async Task<IActionResult> GetJobPostingById([FromRoute] string id)
        {
            var result = await _sender.Send(new GetJobPostingByIdQuery { Id = id });
            return result.IsSuccess
                ? Ok(result)
                : HandleFailure(result);
        }
    }
}
