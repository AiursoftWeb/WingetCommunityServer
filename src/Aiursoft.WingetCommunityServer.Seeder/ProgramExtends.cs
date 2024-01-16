using System.Text.RegularExpressions;
using Aiursoft.GitRunner;
using Aiursoft.GitRunner.Models;
using Aiursoft.WingetCommunityServer.Database;
using Aiursoft.WingetCommunityServer.Seeder.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Aiursoft.WingetCommunityServer.Seeder;

public static class ProgramExtends
{
    public static async Task SeedAsync(this IHost host)
    {
        using var scope = host.Services.CreateScope();
        var services = scope.ServiceProvider;
        var logger = services.GetRequiredService<ILogger<WingetServerDbContext>>();
        //var context = services.GetRequiredService<WingetServerDbContext>();
        var storageConfig = services.GetRequiredService<IOptions<StorageConfig>>();
        var serverConfig = services.GetRequiredService<IOptions<ServerConfig>>();
        var workspaceManager = services.GetRequiredService<WorkspaceManager>();
        var workPath = Path.Combine(storageConfig.Value.Path!, "SeedingRepo");
        var workBranch = serverConfig.Value.UpstreamGitBranch!;
        var cloneEndpoint = serverConfig.Value.UpstreamGit!;
        
        logger.LogInformation("Pulling upstream...");
        await workspaceManager.ResetRepo(workPath, workBranch, cloneEndpoint,
            CloneMode.Depth1);
        logger.LogInformation("Extracing source...");
        
        var builtInPackages = new List<YamlPackage>();
        
        // find all .yaml files under workPath
        var yamlFiles = Directory.GetFiles(workPath, "*.yaml", SearchOption.AllDirectories).Take(1000);
        foreach (var yaml in yamlFiles)
        {
            var yamlContent = await File.ReadAllTextAsync(yaml);
            var manifestType = Regex.Match(yamlContent, @"ManifestType: (.*)").Groups[1].Value;
            if (manifestType.Trim() == "version")
            {
                var packageIdentifier = Regex.Match(yamlContent, @"PackageIdentifier: (.*)").Groups[1].Value;
                var packageVersion = Regex.Match(yamlContent, @"PackageVersion: (.*)").Groups[1].Value;
                var defaultLocale = Regex.Match(yamlContent, @"DefaultLocale: (.*)").Groups[1].Value;
                var manifestVersion = Regex.Match(yamlContent, @"ManifestVersion: (.*)").Groups[1].Value;
                var package = new YamlPackage
                {
                    PackageIdentifier = packageIdentifier,
                    PackageVersion = packageVersion,
                    DefaultLocale = defaultLocale,
                    ManifestType = manifestType,
                    ManifestVersion = manifestVersion
                };
                builtInPackages.Add(package);
            }
        }
        
        logger.LogInformation("Found {Count} packages.", builtInPackages.Count);
    }
}

public class YamlPackage
{
    public string PackageIdentifier { get; set; } = null!;
    public string PackageVersion { get; set; } = null!;
    public string DefaultLocale { get; set; } = null!;
    public string ManifestType { get; set; } = null!;
    public string ManifestVersion { get; set; } = null!;

    public override string ToString()
    {
        return $"{PackageIdentifier} {PackageVersion}";
    }
}

// # Created using wingetcreate 1.5.2.0
// # yaml-language-server: $schema=https://aka.ms/winget-manifest.version.1.5.0.schema.json
//
// PackageIdentifier: 0x192.UniversalAndroidDebloaterGUI
// PackageVersion: 0.5.1
// DefaultLocale: en-US
// ManifestType: version
// ManifestVersion: 1.5.0
