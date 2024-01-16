using Aiursoft.CSTools.Tools;
using Aiursoft.DbTools;
using Aiursoft.WingetCommunityServer.Database;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Aiursoft.WebTools.Extends;

namespace Aiursoft.WingetCommunityServer.Tests.IntegrationTests;

[TestClass]
public class BasicTests
{
    private readonly string _endpointUrl;
    private readonly int _port;
    private readonly HttpClient _http;
    private IHost? _server;

    public BasicTests()
    {
        _port = Network.GetAvailablePort();
        _endpointUrl = $"http://localhost:{_port}";
        _http = new HttpClient();
    }

    [TestInitialize]
    public async Task CreateServer()
    {
        _server = App<Startup>(Array.Empty<string>(), port: _port);
        await _server.UpdateDbAsync<WingetServerDbContext>(UpdateMode.RecreateThenUse);
        await _server.StartAsync();
    }

    [TestCleanup]
    public async Task CleanServer()
    {
        if (_server == null) return;
        await _server.StopAsync();
        _server.Dispose();
    }

    [TestMethod]
    [DataRow("/api/information")]
    [DataRow("/api/information?aaaaaa=bbbbbb")]
    public async Task GetInfo(string url)
    {
        var response = await _http.GetAsync(_endpointUrl + url);
        response.EnsureSuccessStatusCode(); // Status Code 200-299

        Assert.IsTrue((await response.Content.ReadAsStringAsync()).Contains("$type"));
    }
}