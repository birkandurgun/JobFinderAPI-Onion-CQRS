using FluentValidation;

namespace JobFinderAPI.Application.Features.Admins.Commands.AdminLogin
{
    public class AdminLoginCommandValidaton : AbstractValidator<AdminLoginCommand>
    {
        public AdminLoginCommandValidaton()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email address.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.");
        }
    }
}
