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
            DataModel = new InformationData()
        });
    }

    [HttpPost("manifestSearch")]
    public IActionResult ManifestSearch([FromBody]SearchAddressModel model)
    {
        return this.Ok(new ManifestSearchModel
        {
            Data = new List<DataItem>() { new DataItem() }
        });
    }

    [HttpGet("packageManifests/{**packageIdentifier}")]
    public IActionResult PackageManifests([FromRoute]string packageIdentifier)
    {
        logger.LogInformation($"Get package id: {packageIdentifier}");
        return this.Ok(new PackageManifestModel
        {
            Data = new PackageManifestData()
        });
    }

    //[Route("{**path}")]
    //public async Task<IActionResult> Proxy([FromRoute]string path)
    //{
    //    logger.LogInformation($"Proxying path: {path}");

    //    var request = HttpContext.CreateProxyHttpRequest(new Uri("https://www.baidu.com"));
    //    var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, HttpContext.RequestAborted);
    //    await HttpContext.CopyProxyHttpResponse(response);

    //    return new EmptyResult();
    //}
}