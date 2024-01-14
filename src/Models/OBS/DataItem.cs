using Newtonsoft.Json;

namespace WingetCommunityServer.Models;

public class DataItem
{
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty(PropertyName = "$type")]
    public string Type { get; set; } = ObsoleteConsts.CommonType;

    /// <summary>
    /// 
    /// </summary>
    public string PackageIdentifier { get; set; } = ObsoleteConsts.FakePackageIdentifier;

    /// <summary>
    /// 
    /// </summary>
    public string PackageName { get; set; } = ObsoleteConsts.FakePackageName;

    /// <summary>
    /// 
    /// </summary>
    public string Publisher { get; set; } = ObsoleteConsts.FakePackagePublisher;

    /// <summary>
    /// 
    /// </summary>
    public List<SearchVersionsItem> Versions { get; set; } = new List<SearchVersionsItem> { new SearchVersionsItem() };
}