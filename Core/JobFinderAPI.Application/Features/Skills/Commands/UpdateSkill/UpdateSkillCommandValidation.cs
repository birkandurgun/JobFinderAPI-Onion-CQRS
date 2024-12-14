using FluentValidation;

namespace JobFinderAPI.Application.Features.Skills.Commands.UpdateSkill
{
    public class UpdateSkillCommandValidation : AbstractValidator<UpdateSkillCommand>
    {
        public UpdateSkillCommandValidation()
        {
            RuleFor(x => x.SkillName)
                .NotNull().WithMessage("Skill name is required.")
                .NotEmpty().WithMessage("Skill name is required.")
                .MinimumLength(3).WithMessage("Skill name must not be less than 3 characters.");

            RuleFor(x => x.Id)
                .NotNull().WithMessage("Id is required.")
                .NotEmpty().WithMessage("Id is required.");
        }
    }
}
