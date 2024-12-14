using JobFinderAPI.Application.Features.SystemUsers.Commands.ChangePassword;
using JobFinderAPI.Application.Features.SystemUsers.Commands.ForgotPassword;
using JobFinderAPI.Application.Features.SystemUsers.Commands.RefreshToken;
using JobFinderAPI.Application.Features.SystemUsers.Commands.VerifyAccount;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace JobFinderAPI.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : ApiController
    {
        private readonly ISender _sender;

        public UsersController(ISender sender) : base(sender) => _sender = sender;

        [HttpGet]
        public async Task<IActionResult> Verify([FromQuery] string email, [FromQuery] string verificationCode)
        {
            var result = await _sender.Send(new ActivateEmailCommand { Email = email, VerificationCode = verificationCode });
            return result.IsSuccess
                ? Ok(result)
                : HandleFailure(result);
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordCommand command)
        {
            var result = await _sender.Send(command);
            return result.IsSuccess
                ? Ok(result)
                : HandleFailure(result);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordCommand command)
        {
            var result = await _sender.Send(command);
            return result.IsSuccess
                ? Ok(result)
                : HandleFailure(result);
        }

        [HttpPost]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenCommand command)
        {
            var result = await _sender.Send(command);
            return result.IsSuccess
                ? Ok(result)
                : HandleFailure(result);
        }
    }
}
