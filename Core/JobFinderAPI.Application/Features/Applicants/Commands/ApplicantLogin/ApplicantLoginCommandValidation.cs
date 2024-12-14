using FluentValidation;

namespace JobFinderAPI.Application.Features.Applicants.Commands.ApplicantLogin
{
    public class ApplicantLoginCommandValidation : AbstractValidator<ApplicantLoginCommand>
    {
        public ApplicantLoginCommandValidation()
        {
            RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Invalid Email Address.");

            RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required.");
        }
    }
}
