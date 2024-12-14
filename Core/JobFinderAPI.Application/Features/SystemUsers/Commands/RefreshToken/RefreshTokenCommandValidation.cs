using FluentValidation;

namespace JobFinderAPI.Application.Features.SystemUsers.Commands.RefreshToken
{
    public class RefreshTokenCommandValidation : AbstractValidator<RefreshTokenCommand>
    {
        public RefreshTokenCommandValidation()
        {
            RuleFor(x => x.RefreshToken)
                .NotEmpty();

            RuleFor(x => x.AccessToken)
                .NotEmpty();
        }
    }
}
