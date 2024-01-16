namespace Aiursoft.WingetCommunityServer.Seeder.YamlSource;

public class YamlAppsAndFeaturesEntry
{
    public string DisplayName { get; set; } = null!;
    public string Publisher { get; set; } = null!;
    public string DisplayVersion { get; set; } = null!;
    public string InstallerType { get; set; } = null!;
    public override string ToString()
    {
        return $"{DisplayName} {DisplayVersion}";
    }
}