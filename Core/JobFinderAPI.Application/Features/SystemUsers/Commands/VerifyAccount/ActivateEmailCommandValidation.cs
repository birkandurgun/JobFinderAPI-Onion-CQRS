using FluentValidation;

namespace JobFinderAPI.Application.Features.SystemUsers.Commands.VerifyAccount
{
    public class ActivateEmailCommandValidation : AbstractValidator<ActivateEmailCommand>
    {
        public ActivateEmailCommandValidation()
        {
            RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Invalid Email Address.");

            RuleFor(x => x.VerificationCode)
            .NotEmpty();
        }
    }
}
