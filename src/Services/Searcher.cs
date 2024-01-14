using Microsoft.Extensions.Options;
using WingetCommunityServer.Models;
using WingetCommunityServer.Models.Configuration;

namespace WingetCommunityServer.Services;

public class Searcher
{
    private readonly ServerConfig _serverConfig;

    public Searcher(IOptions<ServerConfig> serverConfig)
    {
        _serverConfig = serverConfig.Value;
    }
    
    public PackageMetadataResponse<ManifestSearchResponse> Search(SearchAddressModel model)
    {
        return new PackageMetadataResponse<ManifestSearchResponse>(
            @namespace: _serverConfig.Type!,
            type: nameof(ManifestSearchResponse),
            identifier: _serverConfig.SourceIdentifier!)
        {
            Data = new ManifestSearchResponse()
            {
                new(_serverConfig.Type!, _serverConfig.SourceIdentifier!)
                {
                    PackageIdentifier = "9NRWMJP3717K",
                    PackageName = "Python 3.11",
                    Publisher = "Python Software Foundation",
                    Versions = new List<ManifestSearchVersion>
                    {
                        new(_serverConfig.Type!, _serverConfig.SourceIdentifier!)
                        {
                            PackageVersion = "Unknown",
                            PackageFamilyNames = new List<string>
                            {
                                "PythonSoftwareFoundation.Python.3.11_qbz5n2kfra8p0"
                            }
                        }
                    }
                },
                new(_serverConfig.Type!, _serverConfig.SourceIdentifier!)
                {
                    PackageIdentifier = "9PJPW5LDXLZ5",
                    PackageName = "Python 3.10",
                    Publisher = "Python Software Foundation",
                    Versions = new List<ManifestSearchVersion>
                    {
                        new(_serverConfig.Type!, _serverConfig.SourceIdentifier!)
                        {
                            PackageVersion = "Unknown",
                            PackageFamilyNames = new List<string>
                            {
                                "PythonSoftwareFoundation.Python.3.10_qbz5n2kfra8p0"
                            }
                        }
                    }
                }
            }
        };
    }
}
