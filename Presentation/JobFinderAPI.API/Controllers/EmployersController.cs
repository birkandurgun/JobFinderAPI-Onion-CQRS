using JobFinderAPI.Application.Features.Employers.Commands.CreateLocation;
using JobFinderAPI.Application.Features.Employers.Commands.EmployerLogin;
using JobFinderAPI.Application.Features.Employers.Commands.EmployerRegister;
using JobFinderAPI.Application.Features.Employers.Commands.UpdateDescription;
using JobFinderAPI.Application.Features.Employers.Commands.UpdateLocation;
using JobFinderAPI.Application.Features.Employers.Queries.GetEmployerById;
using JobFinderAPI.Application.Features.Employers.Queries.GetEmployerLocation;
using JobFinderAPI.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobFinderAPI.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize(Roles = nameof(Role.Employer))]
    public class EmployersController : ApiController
    {
        private readonly ISender _sender;
        public EmployersController(ISender sender) : base(sender) 
            => _sender = sender;

        [HttpGet]
        [Route("{id}")]
        [Authorize(Roles = $"{nameof(Role.Admin)},{nameof(Role.Employer)},{nameof(Role.Applicant)}")]
        public async Task<IActionResult> GetEmployerById([FromRoute] string id)
        {
            var result = await _sender.Send(new GetEmployerByIdQuery { Id = id });
            return result.IsSuccess
                ? Ok(result)
                : HandleFailure(result);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> EmployerRegister([FromBody] EmployerRegisterCommand command)
        {
            var result = await _sender.Send(command);
            return result.IsSuccess 
                ? Ok(result)
                : HandleFailure(result);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> EmployerLogin([FromBody] EmployerLoginCommand command)
        {
            var result = await _sender.Send(command);
            return result.IsSuccess
                ? Ok(result)
                : HandleFailure(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateLocation([FromBody] CreateLocationCommand command)
        {
            var result = await _sender.Send(command);
            return result.IsSuccess
                ? Ok(result)
                : HandleFailure(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDescription([FromBody] UpdateDescriptionCommand command)
        {
            var result = await _sender.Send(command);
            return result.IsSuccess
                ? Ok(result)
                : HandleFailure(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateLocation([FromBody] UpdateLocationCommand command)
        {
            var result = await _sender.Send(command);
            return result.IsSuccess
                ? Ok(result)
                : HandleFailure(result);
        }

        [HttpGet]
        [Route("{employerId}")]
        [Authorize(Roles = $"{nameof(Role.Admin)},{nameof(Role.Employer)},{nameof(Role.Applicant)}")]
        public async Task<IActionResult> GetEmployerLocation([FromRoute] string employerId)
        {
            var result = await _sender.Send(new GetEmployerLocationQuery { EmployerId = employerId });
            return result.IsSuccess
                ? Ok(result)
                : HandleFailure(result);
        }
    }
}
