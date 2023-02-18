using Microsoft.VisualBasic;
using Newtonsoft.Json;
using WingetCacheServer.Models;

namespace WingetCacheServer.Models;

public class DefaultLocale
{
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty(PropertyName = "$type")]
    public string Type { get; set; } = Consts.CommonType;

    /// <summary>
    /// 
    /// </summary>
    public string PackageLocale { get; set; } = "en";

    /// <summary>
    /// 
    /// </summary>
    public string Publisher { get; set; } = Consts.FakePackagePublisher;

    /// <summary>
    /// 
    /// </summary>
    public string PublisherUrl { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string PrivacyUrl { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string PublisherSupportUrl { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string PackageName { get; set; } = Consts.FakePackageName;

    /// <summary>
    /// 
    /// </summary>
    public string License { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string Copyright { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string ShortDescription { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public List<string> Tags { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public List<AgreementsItem> Agreements { get; set; }
}
 
public class InstallerSwitches
{
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty(PropertyName = "$type")]
    public string Type { get; set; } = Consts.CommonType;

    /// <summary>
    /// The argument passed to installer to start silent installation
    /// </summary>
    public string Silent { get; set; } = "/S";
}
 
public class AppsAndFeaturesEntriesItem
{
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty(PropertyName = "$type")] 
    public string Type { get; set; } = Consts.CommonType;

    /// <summary>
    /// 
    /// </summary>
    public string DisplayName { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string Publisher { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string DisplayVersion { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string ProductCode { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string InstallerType { get; set; }
}
 
public class Markets
{
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty(PropertyName = "$type")]
    public string Type { get; set; } = Consts.CommonType;

    /// <summary>
    /// 
    /// </summary>
    public List<string> AllowedMarkets { get; set; }
}
 
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
    public List<AppsAndFeaturesEntriesItem> AppsAndFeaturesEntries { get; set; }
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
    public string Scope { get; set; }
}

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
    public List<string> Locales { get; set; } = new List<string> {};

    /// <summary>
    /// 
    /// </summary>
    public List<InstallersItem> Installers { get; set; } = new List<InstallersItem>() { new InstallersItem() };
}

public class PackageManifestData
{
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty(PropertyName = "$type")]
    public string Type { get; set; } = Consts.CommonType;

    /// <summary>
    /// 
    /// </summary>
    public string PackageIdentifier { get; set; } = Consts.FakePackageIdentifier;

    /// <summary>
    /// 
    /// </summary>
    public List<PackageManifestVersionsItem> Versions { get; set; } = new List<PackageManifestVersionsItem>() { new PackageManifestVersionsItem() };
}
 
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
    public PackageManifestData Data { get; set; }
}