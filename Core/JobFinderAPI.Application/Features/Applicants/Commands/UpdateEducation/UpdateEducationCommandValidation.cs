using FluentValidation;

namespace JobFinderAPI.Application.Features.Applicants.Commands.UpdateEducation
{
    public class UpdateEducationCommandValidation : AbstractValidator<UpdateEducationCommand>
    {
        public UpdateEducationCommandValidation()
        {
            RuleFor(x => x.Institution)
                .NotEmpty().WithMessage("Institution is required.")
                .MaximumLength(100).WithMessage("Institution cannot exceed 100 characters.");

            RuleFor(x => x.Field)
                .NotEmpty().WithMessage("Field of study is required.")
                .MaximumLength(100).WithMessage("Field cannot exceed 100 characters.");

            RuleFor(x => x.StartDate)
                .NotEmpty().WithMessage("Start date is required.")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Start date cannot be in the future.");

            RuleFor(x => x.EndDate)
                .GreaterThanOrEqualTo(x => x.StartDate).When(x => x.EndDate.HasValue)
                .WithMessage("End date must be later than or equal to the start date.");

            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("ID is required.")
                .NotEqual(Guid.Empty).WithMessage("ID must be a valid GUID.");
        }
    }
}
