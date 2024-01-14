using Aiursoft.DocGenerator.Attributes;
using Microsoft.AspNetCore.Mvc;
using WingetCommunityServer.Models;
using WingetCommunityServer.Services;

namespace WingetCommunityServer.Controllers;

[GenerateDoc]
[Route("api")]
public class ApiController: ControllerBase
{
    private readonly Searcher _searcher;
    private readonly InformationBuilder _informationBuilder;
    private readonly ILogger<ApiController> _logger;

    public ApiController(
        Searcher searcher,
        InformationBuilder informationBuilder,
        ILogger<ApiController> logger)
    {
        _searcher = searcher;
        _informationBuilder = informationBuilder;
        _logger = logger;
    }

    [HttpGet("information")]
    [Produces(typeof(PackageMetadataResponse))]
    public IActionResult Information()
    {
        return Ok(_informationBuilder.Build());
    }

    [HttpPost("manifestSearch")]
    [Produces(typeof(SearchAddressModel))]
    public async Task<IActionResult> ManifestSearch([FromBody]SearchAddressModel model)
    {
        return Ok(await _searcher.Search(model));
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