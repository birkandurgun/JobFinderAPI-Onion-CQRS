using FluentValidation;

namespace JobFinderAPI.Application.Features.JobPostings.Commands.AddRequiredSkill
{
    public class AddRequiredSkillCommandValidation : AbstractValidator<AddRequiredSkillCommand>
    {
        public AddRequiredSkillCommandValidation()
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
