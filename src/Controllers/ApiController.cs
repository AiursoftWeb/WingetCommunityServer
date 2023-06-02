using Microsoft.AspNetCore.Mvc;
using WingetCommunityServer.Models;

namespace WingetCommunityServer.Controllers;

[Route("api")]
public class ApiController: ControllerBase
{
    private readonly ILogger<ApiController> logger;

    public ApiController(
        ILogger<ApiController> logger)
    {
        this.logger = logger;
    }

    [HttpGet("information")]
    public IActionResult Information()
    {
        return this.Ok(new InformationModel());
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
}