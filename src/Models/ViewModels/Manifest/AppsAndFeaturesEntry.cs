namespace WingetCommunityServer.Models.ViewModels.Manifest;

public class AppsAndFeaturesEntry
{
    public string DisplayName { get; set; } = null!;
    public string Publisher { get; set; } = null!;
    public string DisplayVersion { get; set; } = null!;
    public string ProductCode { get; set; } = null!;
    public string InstallerType { get; set; } = null!;
}