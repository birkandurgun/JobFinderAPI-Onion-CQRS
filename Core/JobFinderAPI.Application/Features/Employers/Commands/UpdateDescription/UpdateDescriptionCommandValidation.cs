using FluentValidation;
using System.Data;

namespace JobFinderAPI.Application.Features.Employers.Commands.UpdateDescription
{
    public class UpdateDescriptionCommandValidation : AbstractValidator<UpdateDescriptionCommand>
    {
        public UpdateDescriptionCommandValidation()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id is required.");

            RuleFor(x => x.Description)
                .NotNull();
        }
    }
}
