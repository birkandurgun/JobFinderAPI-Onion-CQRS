using JobFinderAPI.Application.Features.Admins.Commands.AddAdmin;
using JobFinderAPI.Application.Features.Admins.Commands.AdminLogin;
using JobFinderAPI.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobFinderAPI.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize(Roles = nameof(Role.Admin))]
    public class AdminsController : ApiController
    {
        private readonly ISender _sender;

        public AdminsController(ISender sender) : base(sender) => _sender = sender;

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> AdminLogin([FromBody] AdminLoginCommand command)
        {
            var result = await _sender.Send(command);
            return result.IsSuccess
                ? Ok(result)
                : HandleFailure(result);
        }

        [HttpPost]
        [Authorize(Roles =nameof(Role.Admin))]
        public async Task<IActionResult> AddAdmin([FromBody] AddAdminCommand command)
        {
            var result = await _sender.Send(command);
            return result.IsSuccess
                ? Ok(result)
                : HandleFailure(result);
        }
    }
}
