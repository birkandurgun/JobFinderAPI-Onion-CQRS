using JobFinderAPI.Application.Features.Skills.Commands.CreateMultiSkills;
using JobFinderAPI.Application.Features.Skills.Commands.CreateSkill;
using JobFinderAPI.Application.Features.Skills.Commands.UpdateSkill;
using JobFinderAPI.Application.Features.Skills.Queries.GetAllSkills;
using JobFinderAPI.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobFinderAPI.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize(Roles = nameof(Role.Admin))]
    public class SkillsController : ApiController
    {
        private readonly ISender _sender;

        public SkillsController(ISender sender) : base(sender)
            => _sender = sender;

        [HttpPost]
        public async Task<IActionResult> CreateSkill([FromBody] CreateSkillCommand command)
        {
            var result = await _sender.Send(command);
            return result.IsSuccess
                ? Ok(result)
                : HandleFailure(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMultiSkills([FromBody] CreateMultiSkillsCommand command)
        {
            var result = await _sender.Send(command);
            return result.IsSuccess
                ? Ok(result)
                : HandleFailure(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSkill([FromBody] UpdateSkillCommand command)
        {
            var result = await _sender.Send(command);
            return result.IsSuccess
                ? Ok(result)
                : HandleFailure(result);
        }

        [HttpGet]
        [Authorize(Roles = $"{nameof(Role.Admin)},{nameof(Role.Employer)},{nameof(Role.Applicant)}")]
        public async Task<IActionResult> GetAllSkills()
        {
            var result = await _sender.Send(new GetAllSkillsQuery());
            return result.IsSuccess
                ? Ok(result)
                : HandleFailure(result);
        }
    }
}
