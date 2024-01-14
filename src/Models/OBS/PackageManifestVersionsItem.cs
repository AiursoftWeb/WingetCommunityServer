using Newtonsoft.Json;

namespace WingetCommunityServer.Models;

public class PackageManifestVersionsItem
{
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty(PropertyName = "$type")]
    public string Type { get; set; } = Consts.CommonType;

    /// <summary>
    /// 
    /// </summary>
    public string PackageVersion { get; set; } = Consts.FakePackageVersion;

    /// <summary>
    /// 
    /// </summary>
    public DefaultLocale DefaultLocale { get; set; } = new DefaultLocale();

    /// <summary>
    /// 
    /// </summary>
    public List<string> Locales { get; set; } = new List<string>();

    /// <summary>
    /// 
    /// </summary>
    public List<InstallersItem> Installers { get; set; } = new List<InstallersItem>() { new InstallersItem() };
}