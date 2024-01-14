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
        return new PackageMetadataResponse<PackageMetadataData>(
            @namespace: _serverConfig.Type!,
            type: nameof(PackageMetadataResponse<object>),
            identifier: _serverConfig.SourceIdentifier!)
        {
            Data = new PackageMetadataData(_serverConfig.Type!, _serverConfig.SourceIdentifier!, _serverConfig.AgreementUrl!)
        };
    }
}