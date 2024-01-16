using Aiursoft.WingetCommunityServer.Models.ViewModels.Information;

namespace Aiursoft.WingetCommunityServer.Models.ViewModels.Manifest;

public class Locale: WingetEntity
{
    public string LocaleName { get; set; } = null!;
    public string Publisher { get; set; } = null!;
    public string PublisherUrl { get; set; } = null!;
    public string PrivacyUrl { get; set; } = null!;
    public string PublisherSupportUrl { get; set; } = null!;
    public string PackageName { get; set; } = null!;
    public string License { get; set; } = null!;
    public string ShortDescription { get; set; } = null!;
    public string Description { get; set; } = null!;
    public List<string> Tags { get; set; } = new();
    public List<AgreementDetail> Agreements { get; set; } = new();
}