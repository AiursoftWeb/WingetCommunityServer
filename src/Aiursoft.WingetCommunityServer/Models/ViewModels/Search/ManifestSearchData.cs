namespace Aiursoft.WingetCommunityServer.Models.ViewModels.Search;

public class ManifestSearchData : WingetEntity
{
    public required string PackageIdentifier { get; init; }

    public required string PackageName { get; init; }

    public required string Publisher { get; init; }

    public required List<ManifestSearchVersion> Versions { get; init; }
}