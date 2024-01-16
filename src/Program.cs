using Aiursoft.DbTools;
using Aiursoft.WingetCommunityServer.Data;
using Microsoft.EntityFrameworkCore;
using WingetCommunityServer.Models.Database;
using static Aiursoft.WebTools.Extends;

namespace Aiursoft.WingetCommunityServer;

public static class Program
{
    public static async Task Main(string[] args)
    {
        var app = App<Startup>(args);
        await app.UpdateDbAsync<WingetServerDbContext>(UpdateMode.MigrateThenUse);
        await app.SeedAsync();
        await app.RunAsync();
    }
}

public static class ProgramExtends
{
    public static async Task SeedAsync(this IHost host)
    {
        using var scope = host.Services.CreateScope();
        var services = scope.ServiceProvider;
        var logger = services.GetRequiredService<ILogger<Startup>>();
        var context = services.GetRequiredService<WingetServerDbContext>();
       
    }
}