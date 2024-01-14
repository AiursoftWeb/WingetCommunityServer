using Newtonsoft.Json;

namespace WingetCommunityServer.Models;

public class PackageManifestData
{
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty(PropertyName = "$type")]
    public string Type { get; set; } = Consts.CommonType;

    /// <summary>
    /// 
    /// </summary>
    public string PackageIdentifier { get; set; } = Consts.FakePackageIdentifier;

    /// <summary>
    /// 
    /// </summary>
    public List<PackageManifestVersionsItem> Versions { get; set; } = new List<PackageManifestVersionsItem>() { new PackageManifestVersionsItem() };
}