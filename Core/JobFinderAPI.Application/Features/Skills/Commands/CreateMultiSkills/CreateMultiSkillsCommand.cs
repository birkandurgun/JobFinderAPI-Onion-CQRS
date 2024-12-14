using JobFinderAPI.Application.Interfaces.CommandQuery;

namespace JobFinderAPI.Application.Features.Skills.Commands.CreateMultiSkills
{
    public class CreateMultiSkillsCommand : ICommand
    {
        public IList<string> SkillNames { get; set; }
    }
}
