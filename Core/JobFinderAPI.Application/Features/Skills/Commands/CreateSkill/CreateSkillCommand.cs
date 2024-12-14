using JobFinderAPI.Application.Interfaces.CommandQuery;

namespace JobFinderAPI.Application.Features.Skills.Commands.CreateSkill
{
    public class CreateSkillCommand : ICommand
    {
        public string Name { get; set; }
    }
}
