namespace Aiursoft.WingetCommunityServer.Seeder.YamlSource;

public class YamlInstaller : YamlFromWinget
{
    public List<string> Platform { get; set; } = null!;
    public string MinimumOSVersion { get; set; } = null!;
    public string Scope { get; set; } = null!;
    public List<string> InstallModes { get; set; } = null!;
    public string UpgradeBehavior { get; set; } = null!;
    public List<string> Commands { get; set; } = null!;
    public List<string> FileExtensions { get; set; } = null!;
    public string InstallerType { get; set; } = null!;
    public List<YamlInstallerItem> Installers { get; set; } = null!;
}