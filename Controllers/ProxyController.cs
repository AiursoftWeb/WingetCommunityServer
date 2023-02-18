using Microsoft.AspNetCore.Mvc;
using WingetCacheServer.Services;

namespace WingetCacheServer.Controllers;

[Route("api")]
public class ProxyController: ControllerBase
{
    private readonly HttpClient client;
    private readonly ILogger<ProxyController> logger;

    public ProxyController(
        HttpClient client,
        ILogger<ProxyController> logger)
    {
        this.client = client;
        this.logger = logger;
    }

    [Route("proxy")]
    public async Task<IActionResult> Proxy(string url)
    {
        logger.LogInformation($"Proxying {url}");

        var request = HttpContext.CreateProxyHttpRequest(new Uri("https://www.google.com"));
        var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, HttpContext.RequestAborted);
        await HttpContext.CopyProxyHttpResponse(response);

        return new EmptyResult();
    }
}