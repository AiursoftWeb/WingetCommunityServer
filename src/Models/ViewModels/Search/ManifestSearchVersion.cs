using WingetCommunityServer.Models;

namespace WingetCommunityServer.Services;

public class ManifestSearchVersion : WingetEntity
{
    public ManifestSearchVersion(string @namespace, string identifier) 
        : base(@namespace, nameof(ManifestSearchVersion), identifier)
    {
    }
    
    public required string PackageVersion { get; set; }

    public required List<string> PackageFamilyNames { get; set; }
}