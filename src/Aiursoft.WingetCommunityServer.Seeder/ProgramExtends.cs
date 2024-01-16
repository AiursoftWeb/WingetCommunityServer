using Aiursoft.GitRunner;
using Aiursoft.GitRunner.Models;
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
        var logger = services.GetRequiredService<ILogger<object>>();
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
        logger.LogInformation("Seeding database...");
    }
}