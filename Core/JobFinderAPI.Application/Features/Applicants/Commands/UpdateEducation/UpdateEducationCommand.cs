using JobFinderAPI.Application.Interfaces.CommandQuery;

namespace JobFinderAPI.Application.Features.Applicants.Commands.UpdateEducation
{
    public class UpdateEducationCommand : ICommand
    {
        public Guid Id { get; set; }
        public string Institution { get; set; }
        public string Field { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
