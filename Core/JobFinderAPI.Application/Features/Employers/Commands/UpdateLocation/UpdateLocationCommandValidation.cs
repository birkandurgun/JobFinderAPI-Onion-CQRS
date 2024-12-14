using FluentValidation;

namespace JobFinderAPI.Application.Features.Employers.Commands.UpdateLocation
{
    public class UpdateLocationCommandValidation : AbstractValidator<UpdateLocationCommand>
    {
        public UpdateLocationCommandValidation()
        {
            RuleFor(x => x.EmployerId)
                .NotEmpty().WithMessage("Employer ID is required.");

            RuleFor(x => x.Country)
                .NotEmpty().WithMessage("Country is required.");

            RuleFor(x => x.City)
                .NotEmpty().WithMessage("City is required.");

            RuleFor(x => x.District)
                .NotEmpty().WithMessage("District is required.");

            RuleFor(x => x.AddressLine)
                .NotEmpty().WithMessage("Address line is required.");
        }
    }
}
