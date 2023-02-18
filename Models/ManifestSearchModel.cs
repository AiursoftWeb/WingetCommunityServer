using Newtonsoft.Json;

namespace WingetCacheServer.Models;

public class VersionsItem
{
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty(PropertyName = "$type")]
    public string Type { get; set; } = Consts.CommonType;

    /// <summary>
    /// 
    /// </summary>
    public string PackageVersion { get; set; } = "1.0.0-fake";
}
 
public class DataItem
{
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty(PropertyName = "$type")]
    public string Type { get; set; } = Consts.CommonType;

    /// <summary>
    /// 
    /// </summary>
    public string PackageIdentifier { get; set; } = "VideoLAN.VLC";

    /// <summary>
    /// 
    /// </summary>
    public string PackageName { get; set; } = "VLC";

    /// <summary>
    /// 
    /// </summary>
    public string Publisher { get; set; } = "VideoLAN";

    /// <summary>
    /// 
    /// </summary>
    public List<VersionsItem> Versions { get; set; } = new List<VersionsItem> { new VersionsItem() };
}
 
public class ManifestSearchModel
{
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty(PropertyName = "$type")]
    public string Type { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public List<DataItem> Data { get; set; }
}

