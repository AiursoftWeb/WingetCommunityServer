namespace WingetCommunityServer.Models.ViewModels.Manifest;

public class SparkInstaller : WingetEntity
{
    public string InstallerSha256 { get; set; } = null!;
    public string InstallerUrl { get; set; } = null!;
    public string InstallerLocale { get; set; } = null!;
    public string MinimumOSVersion { get; set; } = null!;
    public InstallerSwitch InstallerSwitches { get; set; } = new();
    public List<AppsAndFeaturesEntry> AppsAndFeaturesEntries { get; set; } = new();
    public string Architecture { get; set; } = null!;
    public string InstallerType { get; set; } = null!;
    public Markets Markets { get; set; } = new();
    public string Scope { get; set; } = null!;
}