using Newtonsoft.Json;

namespace WingetCommunityServer.Models;

public class SearchVersionsItem
{
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty(PropertyName = "$type")]
    public string Type { get; set; } = ObsoleteConsts.CommonType;

    /// <summary>
    /// 
    /// </summary>
    public string PackageVersion { get; set; } = ObsoleteConsts.FakePackageVersion;
}