using Aiursoft.DocGenerator.Attributes;
using Microsoft.AspNetCore.Mvc;
using Aiursoft.WingetCommunityServer.Models.AddressModels;
using Aiursoft.WingetCommunityServer.Models.ViewModels.Information;
using Aiursoft.WingetCommunityServer.Models.ViewModels.Manifest;
using Aiursoft.WingetCommunityServer.Services;

namespace Aiursoft.WingetCommunityServer.Controllers;

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
    [Produces(typeof(PackageManifestResponse))]
    public IActionResult PackageManifests([FromRoute] string packageIdentifier)
    {
        _logger.LogInformation($"Get package id: {packageIdentifier}");
        return Ok(new PackageManifestResponse
        {
            Data = new PackageManifestData()
        });
    }
}