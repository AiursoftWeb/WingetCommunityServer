using Newtonsoft.Json;

namespace WingetCommunityServer.Models;

public class DefaultLocale
{
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty(PropertyName = "$type")]
    public string Type { get; set; } = Consts.CommonType;

    /// <summary>
    /// 
    /// </summary>
    public string PackageLocale { get; set; } = "en";

    /// <summary>
    /// 
    /// </summary>
    public string Publisher { get; set; } = Consts.FakePackagePublisher;

    /// <summary>
    /// 
    /// </summary>
    public string PublisherUrl { get; set; } = "";

    /// <summary>
    /// 
    /// </summary>
    public string PrivacyUrl { get; set; } = "";

    /// <summary>
    /// 
    /// </summary>
    public string PublisherSupportUrl { get; set; } = "";

    /// <summary>
    /// 
    /// </summary>
    public string PackageName { get; set; } = Consts.FakePackageName;

    /// <summary>
    /// 
    /// </summary>
    public string License { get; set; } = "";

    /// <summary>
    /// 
    /// </summary>
    public string Copyright { get; set; } = "";

    /// <summary>
    /// 
    /// </summary>
    public string ShortDescription { get; set; } = "Guess what?";

    /// <summary>
    /// 
    /// </summary>
    public string Description { get; set; } = "Guess what?";

    /// <summary>
    /// 
    /// </summary>
    public List<string> Tags { get; set; } = new List<string>();
    /// <summary>
    /// 
    /// </summary>
    public List<AgreementsItem> Agreements { get; set; } = new List<AgreementsItem>();
}