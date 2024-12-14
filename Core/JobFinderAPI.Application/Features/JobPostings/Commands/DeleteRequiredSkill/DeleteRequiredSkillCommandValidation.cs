using FluentValidation;

namespace JobFinderAPI.Application.Features.JobPostings.Commands.DeleteRequiredSkill
{
    public class DeleteRequiredSkillCommandValidation : AbstractValidator<DeleteRequiredSkillCommand>
    {
        public DeleteRequiredSkillCommandValidation()
        {
            RuleFor(x => x.JobPostingId)
            .NotEmpty().WithMessage("Job Posting ID is required")
            .NotEqual(Guid.Empty).WithMessage("Invalid Job Posting ID");

            RuleFor(x => x.SkillId)
                .NotEmpty().WithMessage("Skill ID is required")
                .NotEqual(Guid.Empty).WithMessage("Invalid Skill ID");
        }
    }
}
