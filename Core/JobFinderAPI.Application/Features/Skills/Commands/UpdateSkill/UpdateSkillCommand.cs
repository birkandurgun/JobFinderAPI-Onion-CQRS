using JobFinderAPI.Application.Interfaces.CommandQuery;

namespace JobFinderAPI.Application.Features.Skills.Commands.UpdateSkill
{
    public class UpdateSkillCommand : ICommand
    {
        public string Id { get; set; }
        public string SkillName { get; set; }
    }
}
