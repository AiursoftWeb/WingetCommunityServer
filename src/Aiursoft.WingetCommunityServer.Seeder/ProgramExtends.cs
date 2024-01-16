using Aiursoft.GitRunner;
using Aiursoft.GitRunner.Models;
using Aiursoft.WingetCommunityServer.Database;
using Aiursoft.WingetCommunityServer.Seeder.Configuration;
using Aiursoft.WingetCommunityServer.Seeder.YamlSource;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace Aiursoft.WingetCommunityServer.Seeder;

public static class ProgramExtends
{
    public static async Task SeedAsync(this IHost host)
    {
        using var scope = host.Services.CreateScope();
        var services = scope.ServiceProvider;
        var seeder = services.GetRequiredService<Seeder>();
        await seeder.SeedAsync();
    }
}

public class Seeder
{
    private readonly IWebHostEnvironment _env;
    private readonly ILogger<Seeder> _logger;
    private readonly WingetServerDbContext _context;
    private readonly WorkspaceManager _workspaceManager;
    private readonly string _workPath;
    private readonly string _workBranch;
    private readonly string _cloneEndpoint;
    
    public Seeder(
        IWebHostEnvironment env,
        ILogger<Seeder> logger,
        WingetServerDbContext context,
        IOptions<StorageConfig> storageConfig,
        IOptions<ServerConfig> serverConfig,
        WorkspaceManager workspaceManager)
    {
        _env = env;
        _logger = logger;
        _context = context;
        _workspaceManager = workspaceManager;
        _workPath = Path.Combine(storageConfig.Value.Path!, "SeedingRepo");
        _workBranch = serverConfig.Value.UpstreamGitBranch!;
        _cloneEndpoint = serverConfig.Value.UpstreamGit!;
    }
    
    public async Task SeedAsync()
    {
        var databaseHasData = await _context.Packages.AnyAsync();
        if (databaseHasData)
        {
            _logger.LogInformation("Database has data. Skip seeding.");
            return;
        }
        
        _logger.LogInformation("Pulling upstream...");
        await _workspaceManager.ResetRepo(_workPath, _workBranch, _cloneEndpoint,
            CloneMode.Depth1);
        _logger.LogInformation("Extracting source...");
        
        var deserializer = new DeserializerBuilder()
            .IgnoreUnmatchedProperties()
            .WithNamingConvention(PascalCaseNamingConvention.Instance)
            .Build();
        var builtInPackages = new List<YamlVersion>();
        var builtInInstallers = new List<YamlInstaller>();
        var builtInLocales = new List<YamlLocale>();

        var yamlFiles = Directory.GetFiles(Path.Combine(_workPath, "manifests"), "*.yaml", SearchOption.AllDirectories);
        if (_env.IsDevelopment())
        {
            _logger.LogInformation("In development mode, only 3000 packages will be loaded.");
            yamlFiles = yamlFiles
                .Take(3000)
                .ToArray();
        }
        
        foreach (var yaml in yamlFiles)
        {
            try
            {
                var yamlContent = await File.ReadAllTextAsync(yaml);
                var deserialized = deserializer.Deserialize<YamlFromWinget>(yamlContent);
                var manifestType = deserialized.ManifestType;
                switch (manifestType.Trim())
                {
                    case "version":
                    {
                        var package = deserializer.Deserialize<YamlVersion>(yamlContent);
                        builtInPackages.Add(package);
                        break;
                    }
                    case "installer":
                    {
                        var installer = deserializer.Deserialize<YamlInstaller>(yamlContent);
                        builtInInstallers.Add(installer);
                        break;
                    }
                    case "defaultLocale":
                    case "locale":
                    {
                        var locale = deserializer.Deserialize<YamlLocale>(yamlContent);
                        builtInLocales.Add(locale);
                        break;
                    }
                    default:
                        _logger.LogWarning("Unknown manifest type: {ManifestType}", manifestType);
                        break;
                }
            }
            catch (Exception e)
            {
                _logger.LogCritical(e, "Failed to parse {Yaml}", yaml);
            }
        }
        
        _logger.LogInformation("Found {Count} packages.", builtInPackages.Count);
        _logger.LogInformation("Found {Count} installers.", builtInInstallers.Count);
        _logger.LogInformation("Found {Count} locales.", builtInLocales.Count);
    }
}