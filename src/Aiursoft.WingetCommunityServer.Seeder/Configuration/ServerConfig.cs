namespace Aiursoft.WingetCommunityServer.Seeder.Configuration;

public class ServerConfig
{
    public string? AgreementUrl { get; init; }
    public string? UpstreamGit { get; init; }
    public string? UpstreamGitBranch { get; init; }
    public bool ShouldUpstreamOnStartup { get; init; }
}