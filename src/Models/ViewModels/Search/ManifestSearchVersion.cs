namespace WingetCommunityServer.Models;

public class ManifestSearchVersion : WingetEntity
{
    public required string PackageVersion { get; init; }

    public required List<string> PackageFamilyNames { get; init; }
}