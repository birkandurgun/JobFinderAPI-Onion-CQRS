using JobFinderAPI.Application.Interfaces.CommandQuery;
using MediatR;

namespace JobFinderAPI.Application.Features.Employers.Commands.EmployerRegister
{
    public class EmployerRegisterCommand : ICommand
    {
        public string Email { get; set; }
        public string CountryCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string CompanyName { get; set; }
    }
}
