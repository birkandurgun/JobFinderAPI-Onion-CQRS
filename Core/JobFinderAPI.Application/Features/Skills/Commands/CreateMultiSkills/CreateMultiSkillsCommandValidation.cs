using FluentValidation;

namespace JobFinderAPI.Application.Features.Skills.Commands.CreateMultiSkills
{
    public class CreateMultiSkillsCommandValidation : AbstractValidator<CreateMultiSkillsCommand>
    {
        public CreateMultiSkillsCommandValidation()
        {
            RuleForEach(x => x.SkillNames)
                .NotEmpty().WithMessage("Skill name is required.")
                .MinimumLength(3).WithMessage("Skill name must not be less than 3 characters.");
        }
    }
}
