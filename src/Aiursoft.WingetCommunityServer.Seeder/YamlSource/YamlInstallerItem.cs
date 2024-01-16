namespace Aiursoft.WingetCommunityServer.Seeder.YamlSource;

public class YamlInstallerItem
{
    public string Architecture { get; set; } = null!;
    public string InstallerType { get; set; } = null!;
    public string InstallerUrl { get; set; } = null!;
    public string InstallerSha256 { get; set; } = null!;
    public Dictionary<string, string> InstallerSwitches { get; set; } = null!;
    public string ProductCode { get; set; } = null!;
    public List<YamlAppsAndFeaturesEntry> AppsAndFeaturesEntries { get; set; } = null!;
    public override string ToString()
    {
        return $"{InstallerUrl} {Architecture}";
    }
}