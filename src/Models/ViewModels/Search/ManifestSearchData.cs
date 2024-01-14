using WingetCommunityServer.Models;

namespace WingetCommunityServer.Services;

public class ManifestSearchData : WingetEntity
{
    public ManifestSearchData(string @namespace, string identifier) 
        : base(@namespace, nameof(ManifestSearchData), identifier)
    {
    }
    
    public required string PackageIdentifier { get; set; }

    public required string PackageName { get; set; }

    public required string Publisher { get; set; }

    public required List<ManifestSearchVersion> Versions { get; set; }
}