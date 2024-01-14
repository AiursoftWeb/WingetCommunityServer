using Newtonsoft.Json;

namespace WingetCommunityServer.Models;

public class PackageMetadataData : WingetEntity
{
    public PackageMetadataData(string @namespace, string identifier) 
        : base(@namespace, nameof(PackageMetadataData), identifier)
    {
        SourceIdentifier = identifier;
        SourceAgreements = new SourceAgreements(@namespace, identifier);
    }
    public required string SourceIdentifier { get; init; }
    public SourceAgreements SourceAgreements { get; init; }
    public required List<string> ServerSupportedVersions { get; init; } 
    public required List<string> RequiredQueryParameters { get; init; } 
    public required List<string> RequiredPackageMatchFields { get; init; }

}