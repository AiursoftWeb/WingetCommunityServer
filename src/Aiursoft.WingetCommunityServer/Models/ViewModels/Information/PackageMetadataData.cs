namespace Aiursoft.WingetCommunityServer.Models.ViewModels.Information;

public class PackageMetadataData : WingetEntity
{
    public PackageMetadataData(string agreementUrl) 
    {
        SourceIdentifier = Consts.ServerId;
        SourceAgreements = new SourceAgreements(agreementUrl);
        ServerSupportedVersions = new List<string>
        {
            "1.0.0",
            "1.1.0"
        };
        RequiredQueryParameters = new List<string>()
        {
            "market"
        };
        RequiredPackageMatchFields = new List<string>()
        {
            "market"
        };
    }
    
    public string SourceIdentifier { get; private init; }
    public SourceAgreements SourceAgreements { get; private init; }
    public List<string> ServerSupportedVersions { get; private init; } 
    public List<string> RequiredQueryParameters { get; private init; } 
    public List<string> RequiredPackageMatchFields { get; private init; }
}