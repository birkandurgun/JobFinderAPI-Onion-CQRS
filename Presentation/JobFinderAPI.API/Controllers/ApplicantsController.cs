using JobFinderAPI.Application.Features.Applicants.Commands.ApplicantLogin;
using JobFinderAPI.Application.Features.Applicants.Commands.ApplicantRegister;
using JobFinderAPI.Application.Features.Applicants.Commands.CreateEducation;
using JobFinderAPI.Application.Features.Applicants.Commands.CreateExperience;
using JobFinderAPI.Application.Features.Applicants.Commands.CreateResume;
using JobFinderAPI.Application.Features.Applicants.Commands.DeleteResume;
using JobFinderAPI.Application.Features.Applicants.Commands.UpdateEducation;
using JobFinderAPI.Application.Features.Applicants.Commands.UpdateExperience;
using JobFinderAPI.Application.Features.Applicants.Queries.GetApplicantById;
using JobFinderAPI.Application.Features.Applicants.Queries.GetApplicantEducations;
using JobFinderAPI.Application.Features.Applicants.Queries.GetApplicantExperiences;
using JobFinderAPI.Application.Features.Applicants.Queries.GetApplicantResume;
using JobFinderAPI.Domain.Entities;
using JobFinderAPI.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobFinderAPI.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize(Roles = nameof(Role.Applicant))]
    public class ApplicantsController : ApiController
    {
        private readonly ISender _sender;
        public ApplicantsController(ISender sender) : base(sender)
            => _sender = sender;

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ApplicantRegister([FromBody] ApplicantRegisterCommand command)
        {
            var result = await _sender.Send(command);
            return result.IsSuccess
                ? Ok(result)
                : HandleFailure(result);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ApplicantLogin([FromBody] ApplicantLoginCommand command)
        {
            var result = await _sender.Send(command);
            return result.IsSuccess
                ? Ok(result)
                : HandleFailure(result);
        }

        [HttpGet]
        [Route("{id}")]
        [Authorize(Roles = $"{nameof(Role.Admin)},{nameof(Role.Employer)},{nameof(Role.Applicant)}")]
        public async Task<IActionResult> GetApplicantById([FromRoute] string id)
        {
            var result = await _sender.Send(new GetApplicantByIdQuery { Id = id });
            return result.IsSuccess
                ? Ok(result)
                : HandleFailure(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEducation([FromBody] CreateEducationCommand command)
        {
            var result = await _sender.Send(command);
            return result.IsSuccess
                ? Ok(result)
                : HandleFailure(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateExperience([FromBody] CreateExperienceCommand command)
        {
            var result = await _sender.Send(command);
            return result.IsSuccess
                ? Ok(result)
                : HandleFailure(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateResume([FromBody] CreateResumeCommand command)
        {
            var result = await _sender.Send(command);
            return result.IsSuccess
                ? Ok(result)
                : HandleFailure(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEducation([FromBody] UpdateEducationCommand command)
        {
            var result = await _sender.Send(command);
            return result.IsSuccess
                ? Ok(result)
                : HandleFailure(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateExperience([FromBody] UpdateExperienceCommand command)
        {
            var result = await _sender.Send(command);
            return result.IsSuccess
                ? Ok(result)
                : HandleFailure(result);
        }

        [HttpDelete]
        [Route("{applicantId}")]
        public async Task<IActionResult> DeleteResume([FromRoute] Guid applicantId)
        {
            var result = await _sender.Send(new DeleteResumeCommand { ApplicantId = applicantId });
            return result.IsSuccess
                ? Ok(result)
                : HandleFailure(result);
        }

        [HttpGet]
        [Route("{applicantId}")]
        [Authorize(Roles = $"{nameof(Role.Admin)},{nameof(Role.Employer)},{nameof(Role.Applicant)}")]
        public async Task<IActionResult> Educations([FromRoute] Guid applicantId)
        {
            var result = await _sender.Send(new GetApplicantEducationsQuery { ApplicantId = applicantId });
            return result.IsSuccess
                ? Ok(result)
                : HandleFailure(result);
        }

        [HttpGet]
        [Route("{applicantId}")]
        [Authorize(Roles = $"{nameof(Role.Admin)},{nameof(Role.Employer)},{nameof(Role.Applicant)}")]
        public async Task<IActionResult> Experiences([FromRoute] Guid applicantId)
        {
            var result = await _sender.Send(new GetApplicantExperiencesQuery { ApplicantId = applicantId });
            return result.IsSuccess
                ? Ok(result)
                : HandleFailure(result);
        }

        [HttpGet]
        [Route("{applicantId}")]
        [Authorize(Roles = $"{nameof(Role.Admin)},{nameof(Role.Employer)},{nameof(Role.Applicant)}")]
        public async Task<IActionResult> Resume([FromRoute] Guid applicantId)
        {
            var result = await _sender.Send(new GetApplicantResumeQuery { ApplicantId = applicantId });
            return result.IsSuccess
                ? Ok(result)
                : HandleFailure(result);
        }

    }
}
