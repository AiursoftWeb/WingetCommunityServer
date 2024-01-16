namespace Aiursoft.WingetCommunityServer.Seeder.YamlSource;

public class YamlFromWinget
{
    public string PackageIdentifier { get; set; } = null!;
    public string PackageVersion { get; set; } = null!;
    public string ManifestType { get; set; } = null!;
    public string ManifestVersion { get; set; } = null!;
    public override string ToString()
    {
        return $"{PackageIdentifier} {PackageVersion}";
    }
}