using JobFinderAPI.Application.Features.Emails.Queries.GetForgotPasswordCode;
using JobFinderAPI.Application.Features.Emails.Queries.GetVerificationCode;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobFinderAPI.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class EmailsController : ApiController
    {
        private readonly ISender _sender;

        public EmailsController(ISender sender) : base(sender)
            => _sender = sender;

        [HttpGet]
        public async Task<IActionResult> GetVerificationCode([FromQuery] string email)
        {
            var result = await _sender.Send(new GetVerificationCodeQuery { Email = email});
            return result.IsSuccess
                ? Ok(result)
                : HandleFailure(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetForgotPasswordCode([FromQuery] string email)
        {
            var result = await _sender.Send(new GetForgotPasswordCodeQuery { Email = email });
            return result.IsSuccess
                ? Ok(result)
                : HandleFailure(result);
        }

    }
}
