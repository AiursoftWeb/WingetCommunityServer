using Aiursoft.DbTools;
using Aiursoft.WingetCommunityServer.Database;
using Aiursoft.WingetCommunityServer.Seeder;
using static Aiursoft.WebTools.Extends;

namespace Aiursoft.WingetCommunityServer;

public static class Program
{
    public static async Task Main(string[] args)
    {
        var app = App<Startup>(args);
        await app.UpdateDbAsync<WingetServerDbContext>(UpdateMode.CreateThenUse);
        await app.SeedAsync();
        await app.RunAsync();
    }
}

