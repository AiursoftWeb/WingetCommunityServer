namespace WingetCommunityServer.Models.ViewModels.Manifest;

public class PackageManifestResponse : WingetEntity
{
    public PackageManifestData Data { get; set; } = new();
}