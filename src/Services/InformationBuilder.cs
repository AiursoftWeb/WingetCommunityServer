using Microsoft.Extensions.Options;
using WingetCommunityServer.Models;
using WingetCommunityServer.Models.Configuration;

namespace WingetCommunityServer.Services;

public class InformationBuilder
{
    private readonly ServerConfig _serverConfig;

    public InformationBuilder(IOptions<ServerConfig> serverConfig)
    {
        _serverConfig = serverConfig.Value;
    }
    
    public PackageMetadataResponse<PackageMetadataData> Build()
    {
        // Reference: https://storeedgefd.dsx.mp.microsoft.com/v9.0/information
        var fullType = $"{_serverConfig.Type}, {_serverConfig.SourceIdentifier}";

        return new PackageMetadataResponse<PackageMetadataData>(_serverConfig.Type!, _serverConfig.SourceIdentifier!)
        {
            Data = new PackageMetadataData(_serverConfig.Type!, _serverConfig.SourceIdentifier!)
            {
                ServerSupportedVersions = new List<string>
                {
                    "1.0.0",
                    "1.1.0"
                },
                RequiredQueryParameters = new List<string>()
                {
                    "market"
                },
                RequiredPackageMatchFields = new List<string>()
                {
                    "market"
                }
            }
        };
    }
}