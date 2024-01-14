using Newtonsoft.Json;

namespace WingetCommunityServer.Models;

public class InstallersItem
{
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty(PropertyName = "$type")]
    public string Type { get; set; } = Consts.CommonType;

    /// <summary>
    /// 
    /// </summary>
    public string InstallerSha256 { get; set; } = Consts.FakePackageInstallSha256;
    /// <summary>
    /// 
    /// </summary>
    public string InstallerUrl { get; set; } = Consts.FakePackageInstallUrl;
    /// <summary>
    /// 
    /// </summary>
    public string InstallerLocale { get; set; } = "en";
    /// <summary>
    /// 
    /// </summary>
    public string MinimumOSVersion { get; set; } = "0.0.0.0";
    /// <summary>
    /// 
    /// </summary>
    public InstallerSwitches InstallerSwitches { get; set; } = new InstallerSwitches();
    /// <summary>
    /// 
    /// </summary>
    public List<AppsAndFeaturesEntriesItem> AppsAndFeaturesEntries { get; set; } = new List<AppsAndFeaturesEntriesItem>() { new AppsAndFeaturesEntriesItem() };
    /// <summary>
    /// 
    /// </summary>
    public string Architecture { get; set; } = "x64";
    /// <summary>
    /// 
    /// </summary>
    public string InstallerType { get; set; } = Consts.FakePackageInstallType;
    /// <summary>
    /// 
    /// </summary>
    public Markets Markets { get; set; } = new Markets();
    /// <summary>
    /// 
    /// </summary>
    public string Scope { get; set; } = "machine";
}