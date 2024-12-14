using JobFinderAPI.Domain.Entities.Common.User;

namespace JobFinderAPI.Domain.Entities
{
    public class Admin : SystemUser {
        public string Username { get; set; }
    }
}
