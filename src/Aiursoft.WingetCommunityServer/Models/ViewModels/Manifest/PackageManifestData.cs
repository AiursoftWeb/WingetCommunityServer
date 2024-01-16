namespace Aiursoft.WingetCommunityServer.Models.ViewModels.Manifest;

public class PackageManifestData: WingetEntity
{
    public string PackageIdentifier { get; set; } = null!;
    public List<PackageManifestVersion> Versions { get; set; } = new();
}