using Newtonsoft.Json;

namespace WingetCommunityServer.Models;

public class ManifestSearchModel
{
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty(PropertyName = "$type")]
    public string Type { get; set; } = ObsoleteConsts.CommonType;

    /// <summary>
    /// 
    /// </summary>
    public List<DataItem> Data { get; set; } = new List<DataItem>();
}

