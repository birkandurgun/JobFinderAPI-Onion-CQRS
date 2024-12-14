using FluentValidation;

namespace JobFinderAPI.Application.Features.Applicants.Commands.CreateResume
{
    public class CreateResumeCommandValidation : AbstractValidator<CreateResumeCommand>
    {
        public CreateResumeCommandValidation()
        {
            RuleFor(x => x.ApplicantId)
                .NotEmpty().WithMessage("Applicant ID is required.")
                .NotEqual(Guid.Empty).WithMessage("Applicant ID must be a valid GUID.");

            RuleFor(x => x.Url)
                .NotEmpty().WithMessage("Resume URL is required.");
        }
    }
}
