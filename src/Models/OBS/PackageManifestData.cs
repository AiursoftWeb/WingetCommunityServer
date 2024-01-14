using Newtonsoft.Json;

namespace WingetCommunityServer.Models;

public class PackageManifestData
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
    public List<PackageManifestVersionsItem> Versions { get; set; } = new List<PackageManifestVersionsItem>() { new PackageManifestVersionsItem() };
}