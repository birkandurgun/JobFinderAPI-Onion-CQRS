using JobFinderAPI.Application.Interfaces.CommandQuery;

namespace JobFinderAPI.Application.Features.SystemUsers.Commands.RefreshToken
{
    public class RefreshTokenCommand : ICommand
    {
        public string RefreshToken { get; set; }
        public string AccessToken { get; set; }
    }
}
