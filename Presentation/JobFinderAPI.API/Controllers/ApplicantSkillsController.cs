using JobFinderAPI.Application.Features.ApplicantSkills.Commands.CreateApplicantSkill;
using JobFinderAPI.Application.Features.ApplicantSkills.Commands.DeleteApplicantSkill;
using JobFinderAPI.Application.Features.ApplicantSkills.Queries.GetApplicantSkills;
using JobFinderAPI.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobFinderAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantSkillsController : ApiController
    {
        private readonly ISender _sender;
        public ApplicantSkillsController(ISender sender) : base(sender) => _sender = sender;

        [HttpPost]
        [Authorize(Roles = nameof(Role.Applicant))]
        public async Task<IActionResult> CreateApplicantSkill([FromBody] CreateApplicantSkillCommand command)
        {
            var result = await _sender.Send(command);
            return result.IsSuccess
                ? Ok(result)
                : HandleFailure(result);
        }

        [HttpDelete]
        [Route("{applicantId}/{skillId}")]
        [Authorize(Roles = nameof(Role.Applicant))]
        public async Task<IActionResult> DeleteApplicantSkill([FromRoute] Guid applicantId, [FromRoute] Guid skillId)
        {
            var result = await _sender.Send(new DeleteApplicantSkillCommand
            {
                ApplicantId = applicantId,
                SkillId = skillId
            });

            return result.IsSuccess
                ? Ok(result)
                : HandleFailure(result);
        }

        [HttpGet]
        [Route("{applicantId}")]
        [Authorize(Roles = $"{nameof(Role.Admin)},{nameof(Role.Employer)},{nameof(Role.Applicant)}")]
        public async Task<IActionResult> GetApplicantSkills([FromRoute] Guid applicantId)
        {
            var result = await _sender.Send(new GetApplicantSkillsQuery { ApplicantId = applicantId });
            return result.IsSuccess
                ? Ok(result)
                : HandleFailure(result);
        }
    }
}
