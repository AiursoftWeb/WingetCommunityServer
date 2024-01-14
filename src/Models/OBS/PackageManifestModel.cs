using Newtonsoft.Json;

namespace WingetCommunityServer.Models;

public class PackageManifestModel
{
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty(PropertyName = "$type")]
    public string Type { get; set; } = Consts.CommonType;

    /// <summary>
    /// 
    /// </summary>
    public PackageManifestData? Data { get; set; }
}