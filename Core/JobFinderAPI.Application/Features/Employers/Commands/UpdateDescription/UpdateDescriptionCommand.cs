using JobFinderAPI.Application.Interfaces.CommandQuery;

namespace JobFinderAPI.Application.Features.Employers.Commands.UpdateDescription
{
    public class UpdateDescriptionCommand : ICommand
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
    }
}
