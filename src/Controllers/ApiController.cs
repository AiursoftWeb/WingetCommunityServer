using Aiursoft.DocGenerator.Attributes;
using Microsoft.AspNetCore.Mvc;
using WingetCommunityServer.Models;
using WingetCommunityServer.Services;

namespace WingetCommunityServer.Controllers;

[GenerateDoc]
[Route("api")]
public class ApiController: ControllerBase
{
    private readonly InformationBuilder _informationBuilder;
    private readonly ILogger<ApiController> _logger;

    public ApiController(
        InformationBuilder informationBuilder,
        ILogger<ApiController> logger)
    {
        _informationBuilder = informationBuilder;
        _logger = logger;
    }

    [HttpGet("information")]
    public IActionResult Information()
    {
        return Ok(_informationBuilder.Build());
    }

    [HttpPost("manifestSearch")]
    [Produces(typeof(ManifestSearchModel))]
    public IActionResult ManifestSearch([FromBody]SearchAddressModel model)
    {
        return Ok(new ManifestSearchModel
        {
            Data = new List<DataItem>() { new() }
        });
    }

    [HttpGet("packageManifests/{**packageIdentifier}")]
    [Produces(typeof(PackageManifestModel))]
    public IActionResult PackageManifests([FromRoute] string packageIdentifier)
    {
        _logger.LogInformation($"Get package id: {packageIdentifier}");
        return Ok(new PackageManifestModel
        {
            Data = new PackageManifestData()
        });
    }
}