using Microsoft.Extensions.Options;
using Aiursoft.WingetCommunityServer.Models.ViewModels.Information;
using Aiursoft.WingetCommunityServer.Seeder.Configuration;

namespace Aiursoft.WingetCommunityServer.Services;

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