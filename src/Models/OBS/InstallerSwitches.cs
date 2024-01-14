using Newtonsoft.Json;

namespace WingetCommunityServer.Models;

public class InstallerSwitches
{
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty(PropertyName = "$type")]
    public string Type { get; set; } = Consts.CommonType;

    /// <summary>
    /// The args passed to installer to start silent installation
    /// For msi/wix packages, winget default to quiet installation, so no args set here
    /// </summary>
    public string Silent { get; set; } = "";
}