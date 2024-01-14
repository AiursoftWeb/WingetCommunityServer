using Newtonsoft.Json;

namespace WingetCommunityServer.Models;

public class AppsAndFeaturesEntriesItem
{
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty(PropertyName = "$type")] 
    public string Type { get; set; } = ObsoleteConsts.CommonType;

    /// <summary>
    /// 
    /// </summary>
    public string DisplayName { get; set; } = "";

    /// <summary>
    /// 
    /// </summary>
    public string Publisher { get; set; } = "";

    /// <summary>
    /// 
    /// </summary>
    public string DisplayVersion { get; set; } = "";

    /// <summary>
    /// 
    /// </summary>
    public string ProductCode { get; set; } = "";

    /// <summary>
    /// Available types: 
    /// https://github.com/microsoft/winget-cli/blob/master/src/AppInstallerCommonCore/Manifest/ManifestCommon.cpp
    /// </summary>
    public string InstallerType { get; set; } = ObsoleteConsts.FakePackageInstallType;
}