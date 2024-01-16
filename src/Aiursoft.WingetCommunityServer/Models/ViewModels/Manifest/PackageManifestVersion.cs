namespace Aiursoft.WingetCommunityServer.Models.ViewModels.Manifest;

public class PackageManifestVersion: WingetEntity
{
    public string PackageVersion { get; set; } = null!;
    public Locale DefaultLocale { get; set; } = new();
    public List<Locale> Locales { get; set; } = new();
    public List<SparkInstaller> Installers { get; set; } = new();
}