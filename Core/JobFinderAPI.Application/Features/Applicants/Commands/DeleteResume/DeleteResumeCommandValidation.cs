using FluentValidation;

namespace JobFinderAPI.Application.Features.Applicants.Commands.DeleteResume
{
    public class DeleteResumeCommandValidation : AbstractValidator<DeleteResumeCommand>
    {
        public DeleteResumeCommandValidation()
        {
            RuleFor(x => x.ApplicantId)
                .NotEmpty().WithMessage("ID is required.")
                .NotEqual(Guid.Empty).WithMessage("ID must be a valid GUID");
        }
    }
}
