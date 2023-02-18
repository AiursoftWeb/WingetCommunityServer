using Newtonsoft.Json;

namespace WingetCacheServer.Models;

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

public class SourceAgreements
{
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty(PropertyName = "$type")]
    public string Type { get; set; } = Consts.CommonType;
    /// <summary>
    /// 
    /// </summary>
    public string AgreementsIdentifier { get; set; } = Consts.ServerName;
    /// <summary>
    /// 
    /// </summary>
    public List<AgreementsItem> Agreements { get; set; } = new List<AgreementsItem>();
}

public class Data
{
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty(PropertyName = "$type")]
    public string Type { get; set; } = Consts.CommonType;
    /// <summary>
    /// 
    /// </summary>
    public string SourceIdentifier { get; set; } = Consts.CommonType;
    /// <summary>
    /// 
    /// </summary>
    public SourceAgreements SourceAgreements { get; set; } = new SourceAgreements();
    /// <summary>
    /// 
    /// </summary>
    public List<string> ServerSupportedVersions { get; set; } = new List<string> { "1.0.0", "1.1.0" };
    /// <summary>
    /// 
    /// </summary>
    public List<string> RequiredQueryParameters { get; set; } = new List<string>();
    /// <summary>
    /// 
    /// </summary>
    public List<string> RequiredPackageMatchFields { get; set; } = new List<string>();
}

public class InformationModel
{
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty(PropertyName = "$type")]
    public string Type { get; set; } = Consts.CommonType;
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty(PropertyName = "Data")]
    public Data DataModel { get; set; }
}