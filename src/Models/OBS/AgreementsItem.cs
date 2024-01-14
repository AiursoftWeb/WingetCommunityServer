using Newtonsoft.Json;

namespace WingetCommunityServer.Models;

public class AgreementsItem
{
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty(PropertyName = "$type")]
    public string Type { get; set; } = Consts.CommonType;
    /// <summary>
    /// 
    /// </summary>
    public string AgreementLabel { get; set; } = "Terms of Transaction";
    /// <summary>
    /// 
    /// </summary>
    public string AgreementUrl { get; set; } = string.Empty;
}