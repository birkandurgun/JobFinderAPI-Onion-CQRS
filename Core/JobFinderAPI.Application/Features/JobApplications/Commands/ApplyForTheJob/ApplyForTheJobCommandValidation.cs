using FluentValidation;

namespace JobFinderAPI.Application.Features.JobApplications.Commands.ApplyForTheJob
{
    public class ApplyForTheJobCommandValidation : AbstractValidator<ApplyForTheJobCommand>
    {
        public ApplyForTheJobCommandValidation()
        {
            RuleFor(x => x.ApplicantId)
                .NotEmpty().WithMessage("ApplicantId is required.");

            RuleFor(x => x.JobPostingId)
                .NotEmpty().WithMessage("JobPostingId is required.");
        }
    }
}
