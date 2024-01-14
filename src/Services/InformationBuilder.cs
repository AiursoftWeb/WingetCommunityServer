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
    
    public PackageMetadataResponse Build()
    {
        return new PackageMetadataResponse
        {
            Data = new PackageMetadataData(_serverConfig.AgreementUrl!)
        };
    }
}