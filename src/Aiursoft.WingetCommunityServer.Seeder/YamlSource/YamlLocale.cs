namespace Aiursoft.WingetCommunityServer.Seeder.YamlSource;

public class YamlLocale : YamlFromWinget
{
    public string PackageLocale { get; set; } = null!;
    public string Publisher { get; set; } = null!;
    public string PublisherUrl { get; set; } = null!;
    public string PublisherSupportUrl { get; set; } = null!;
    public string Author { get; set; } = null!;
    public string PackageName { get; set; } = null!;
    public string PackageUrl { get; set; } = null!;
    public string License { get; set; } = null!;
    public string LicenseUrl { get; set; } = null!;
    public string Copyright { get; set; } = null!;
    public string CopyrightUrl { get; set; } = null!;
    public string ShortDescription { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Moniker { get; set; } = null!;
    public List<string> Tags { get; set; } = null!;
    
}