using Microsoft.AspNetCore.Mvc;
using WingetCacheServer.Models;
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

    [HttpGet("information")]
    public IActionResult Information()
    {
        return this.Ok(new InformationModel
        {
            DataModel = new Data()
        });
    }

    [HttpPost("manifestSearch")]
    public IActionResult ManifestSearch([FromBody]SearchAddressModel model)
    {
        return this.Ok();
    }

    [Route("{**path}")]
    public async Task<IActionResult> Proxy([FromRoute]string path)
    {
        logger.LogInformation($"Proxying path: {path}");

        // var request = HttpContext.CreateProxyHttpRequest(new Uri(url));
        // var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, HttpContext.RequestAborted);
        // await HttpContext.CopyProxyHttpResponse(response);

        return new EmptyResult();
    }
}