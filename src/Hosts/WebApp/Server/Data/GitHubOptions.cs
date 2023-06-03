namespace WebApp.Server.Data
{
    public class GitHubOptions
    {
        public const string GitHubConfigurationSection = "GitHub";

        public string ClientId { get; set; } = null!;
        public string ClientSecret { get; set; } = null!;
    }
}
