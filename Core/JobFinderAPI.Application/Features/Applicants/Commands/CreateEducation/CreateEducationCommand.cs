using JobFinderAPI.Application.Interfaces.CommandQuery;

namespace JobFinderAPI.Application.Features.Applicants.Commands.CreateEducation
{
    public class CreateEducationCommand : ICommand
    {
        public string Institution { get; set; }
        public string Field { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public Guid ApplicantId { get; set; }
    }
}
