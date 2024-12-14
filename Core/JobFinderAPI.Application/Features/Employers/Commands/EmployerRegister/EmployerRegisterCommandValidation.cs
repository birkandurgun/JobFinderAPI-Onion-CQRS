﻿using FluentValidation;
using System.Text.RegularExpressions;

namespace JobFinderAPI.Application.Features.Employers.Commands.EmployerRegister
{
    public class EmployerRegisterCommandValidation : AbstractValidator<EmployerRegisterCommand>
    {
        public EmployerRegisterCommandValidation() 
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email address.");

            RuleFor(x => x.CountryCode)
            .NotEmpty().WithMessage("Country code is required.")
            .Matches(@"^\d{1,4}$").WithMessage("Country code must be 1 to 4 digits.");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("Phone number is required.")
                .Matches(@"^\d{10,15}$").WithMessage("Phone number must be between 10 and 15 digits and contain only numbers.");

            RuleFor(x => x.CompanyName)
                .NotEmpty().WithMessage("Company name is required.")
                .MaximumLength(200).WithMessage("Company name must not be more than 200 characters.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(8).WithMessage("Password must be at least 8 characters long.")
                .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
                .Matches("[a-z]").WithMessage("Password must contain at least one uppercase letter.")
                .Matches("[0-9]").WithMessage("Password must contain at least one number.")
                .Matches("[^a-zA-Z0-9]").WithMessage("Password must contain at least one special character.");

            RuleFor(u => u.ConfirmPassword)
                .NotEmpty().WithMessage("Confirm password is required.")
                .Equal(u => u.Password).WithMessage("Passwords must match.");
        }
    }
}