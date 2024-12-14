using JobFinderAPI.Application.Interfaces.CommandQuery;

namespace JobFinderAPI.Application.Features.Applicants.Commands.CreateExperience
{
    public class CreateExperienceCommand : ICommand
    {
        public string Title { get; set; }
        public string Company { get; set; }
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public Guid ApplicantId { get; set; }
    }
}
