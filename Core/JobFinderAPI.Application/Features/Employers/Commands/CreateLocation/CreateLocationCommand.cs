﻿using JobFinderAPI.Application.Interfaces.CommandQuery;

namespace JobFinderAPI.Application.Features.Employers.Commands.CreateLocation
{
    public class CreateLocationCommand : ICommand
    {
        public Guid EmployerId { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string AddressLine { get; set; }
    }
}