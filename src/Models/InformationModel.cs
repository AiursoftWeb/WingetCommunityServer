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
    public List<AgreementsItem> Agreements { get; set; } = new();
}

public class InformationData
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
    public SourceAgreements SourceAgreements { get; set; } = new();
    /// <summary>
    /// 
    /// </summary>
    public List<string> ServerSupportedVersions { get; set; } = new() { "1.0.0", "1.1.0" };
    /// <summary>
    /// 
    /// </summary>
    public List<string> RequiredQueryParameters { get; set; } = new();
    /// <summary>
    /// 
    /// </summary>
    public List<string> RequiredPackageMatchFields { get; set; } = new();
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
    public InformationData? DataModel { get; set; } = new ();
}