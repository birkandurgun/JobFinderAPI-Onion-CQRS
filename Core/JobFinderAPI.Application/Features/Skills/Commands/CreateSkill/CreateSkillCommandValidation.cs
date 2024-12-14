using FluentValidation;

namespace JobFinderAPI.Application.Features.Skills.Commands.CreateSkill
{
    public class CreateSkillCommandValidation : AbstractValidator<CreateSkillCommand>
    {
        public CreateSkillCommandValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Skill name is required.")
                .MinimumLength(3).WithMessage("Skill name must not be less than 3 characters.");
        }
    }
}
