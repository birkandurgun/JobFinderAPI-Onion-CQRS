using FluentValidation;

namespace JobFinderAPI.Application.Features.ApplicantSkills.Commands.CreateApplicantSkill
{
    public class CreateApplicantSkillCommandValidation : AbstractValidator<CreateApplicantSkillCommand>
    {
        public CreateApplicantSkillCommandValidation()
        {
            RuleFor(x => x.ApplicantId)
                .NotEmpty().WithMessage("ApplicantId is required.");

            RuleFor(x => x.SkillIds)
                .NotEmpty().WithMessage("At least one SkillId must be provided.")
                .Must(skillIds => skillIds.All(skillId => skillId != Guid.Empty))
                .WithMessage("Each SkillId must be a valid GUID.");
        }
    }
}
