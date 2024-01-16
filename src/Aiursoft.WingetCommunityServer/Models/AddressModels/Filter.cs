namespace Aiursoft.WingetCommunityServer.Models.AddressModels;

public class Filter
{
    /// <summary>
    /// May be "Market"
    /// </summary>
    public string? PackageMatchField { get; set; }

    public Query? RequestMatch { get; set; }
}