namespace JobFinderAPI.Infrastructure.Settings
{
    public class PasswordHashingSettings
    {
        public string Pepper { get; set; }
        public int Iteration { get; set; }
    }
}
