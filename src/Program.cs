using static Aiursoft.WebTools.Extends;

namespace Aiursoft.WingetCommunityServer;

public static class Program
{
    public static async Task Main(string[] args)
    {
        await App<Startup>(args).RunAsync();
    }
}