using FluentValidation;

namespace JobFinderAPI.Application.Features.ApplicantSkills.Commands.DeleteApplicantSkill
{
    public class DeleteApplicantSkillCommandValidation : AbstractValidator<DeleteApplicantSkillCommand>
    {
        public DeleteApplicantSkillCommandValidation()
        {
            RuleFor(x => x.ApplicantId)
                .NotEmpty().WithMessage("ApplicantId is required.");

            RuleFor(x => x.SkillId)
                .NotEmpty().WithMessage("SkillId is required.");
        }
    }
}
