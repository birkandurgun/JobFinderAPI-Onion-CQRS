﻿using FluentValidation;

namespace JobFinderAPI.Application.Features.Admins.Commands.AddAdmin
{
    public class AddAdminCommandValidaton : AbstractValidator<AddAdminCommand>
    {
        public AddAdminCommandValidaton()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email address.");

            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("Username is required.")
                .Length(3, 50).WithMessage("Username must be between 3 and 50 characters.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(8).WithMessage("Password must be at least 8 characters long.")
                .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
                .Matches("[a-z]").WithMessage("Password must contain at least one lowercase letter.")
                .Matches("[0-9]").WithMessage("Password must contain at least one number.")
                .Matches("[^a-zA-Z0-9]").WithMessage("Password must contain at least one special character.");

            RuleFor(x => x.CountryCode)
            .NotEmpty().WithMessage("Country code is required.")
            .Matches(@"^\d{1,4}$").WithMessage("Country code must be 1 to 4 digits.");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("Phone number is required.")
                .Matches(@"^\d{10,15}$").WithMessage("Phone number must be between 10 and 15 digits and contain only numbers.");
        }
    }
}