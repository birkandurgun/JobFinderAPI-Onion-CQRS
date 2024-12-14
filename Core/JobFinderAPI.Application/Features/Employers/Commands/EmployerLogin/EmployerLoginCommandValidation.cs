using FluentValidation;

namespace JobFinderAPI.Application.Features.Employers.Commands.EmployerLogin
{
    public class EmployerLoginCommandValidation : AbstractValidator<EmployerLoginCommand>
    {
        public EmployerLoginCommandValidation()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid Email Address.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.");
        }
    }
}
