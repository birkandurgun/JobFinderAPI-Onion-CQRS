using FluentValidation;
using JobFinderAPI.Domain.Enums;

namespace JobFinderAPI.Application.Features.JobPostings.Commands.CreateJobPosting
{
    public class CreateJobPostingCommandValidation : AbstractValidator<CreateJobPostingCommand>
    {
        public CreateJobPostingCommandValidation()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Job title is required")
                .MaximumLength(200).WithMessage("Job title must not be more than 200 characters");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Job description is required")
                .MinimumLength(30).WithMessage("Job description must be at least 30 characters long")
                .MaximumLength(2000).WithMessage("Job description must not exceed 2000 characters");

            RuleFor(x => x.EmployerId)
                .NotEmpty().WithMessage("Employer ID is required")
                .NotEqual(Guid.Empty).WithMessage("Invalid Employer ID");

            RuleFor(x => x.RequiredSkillIds)
                .NotNull().WithMessage("At least one skill is required")
                .Must(skills => skills != null && skills.Count > 0).WithMessage("At least one skill is required");

            RuleFor(x => x.WorkPreference)
                .Must(wp => Enum.IsDefined(typeof(WorkPreference), wp)).WithMessage("Invalid work preference");

            RuleFor(x => x.Sector)
                .Must(s => Enum.IsDefined(typeof(Sector), s)).WithMessage("Invalid sector");
        }
    }
}
