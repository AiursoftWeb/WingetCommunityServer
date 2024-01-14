using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WingetCommunityServer.Models.Database;

public class Package
{
    [Key]
    public int DatabaseId { get; set; }
    public required string Id { get; init; }
    public required string Name { get; init; }
    public required string Version { get; init; }
    public required string Publisher { get; init; }
    
    /// <summary>
    /// Sample: PythonSoftwareFoundation.Python.3.11_qbz5n2kfra8p0
    /// </summary>
    [NotMapped]
    public string PackageFamilyName => $"{Publisher.Replace(" ", "")}.{Name.Replace(" ", "")}.{DatabaseId.GetHashCode()}";
    
    [InverseProperty(nameof(PackageVersion.Package))]
    public IEnumerable<PackageVersion>? Versions { get; set; }
}

public class PackageVersion
{
    [Key]
    public int DatabaseId { get; set; }
    
    public required int PackageId { get; init; }
    [ForeignKey(nameof(PackageId))]
    public Package Package { get; init; } = null!;
    
    public required string Version { get; init; }
    
    public required string InstallerType { get; init; }
    
    public required string Scope { get; init; }
    
    public required string InstallModes { get; init; }
    
    public required string InstallerSwitches { get; init; }
    
    public required string InstallerSuccessCodes { get; init; }
    
    public required string UpgradeBehavior { get; init; }
    
    public required string Protocols { get; init; }
    
    public required string FileExtensions { get; init; }
    
    public required DateTime ReleaseDate { get; init; }
    
    [InverseProperty(nameof(PackageVersionInstaller.PackageVersion))]
    public IEnumerable<PackageVersionInstaller>? Installers { get; set; }
    
    [InverseProperty(nameof(PackageVersionLocale.PackageVersion))]
    public IEnumerable<PackageVersionLocale>? Locales { get; set; }
}

public class PackageVersionInstaller
{
    [Key]
    public int DatabaseId { get; set; }
    
    public required int PackageVersionId { get; init; }
    [ForeignKey(nameof(PackageVersionId))]
    public PackageVersion PackageVersion { get; init; } = null!;
    
    public required string Architecture { get; init; }
    
    public required string InstallerUrl { get; init; }
    
    public required string InstallerSha256 { get; init; }
    
    public required string ProductCode { get; init; }
}

public class PackageVersionLocale
{
    [Key]
    public int DatabaseId { get; set; }
    
    public required int PackageVersionId { get; init; }
    [ForeignKey(nameof(PackageVersionId))]
    public PackageVersion PackageVersion { get; init; } = null!;
    
    public required string PackageLocale { get; init; }
    
    public string? Publisher { get; init; }
    
    public string? PublisherUrl { get; init; }
    
    public string? PublisherSupportUrl { get; init; }
    
    public string? PrivacyUrl { get; init; }
    
    public string? Author { get; init; }
    
    public string? PackageName { get; init; }
    
    public string? PackageUrl { get; init; }
    
    public string? License { get; init; }
    
    public string? LicenseUrl { get; init; }
    
    public string? CopyRight { get; init; }
    
    public string? CopyRightUrl { get; init; }
    
    public string? ShortDescription { get; init; }
    
    public string? Description { get; init; }
    
    public string? Tags { get; init; }
    
    public string? ReleaseNotes { get; init; }
    
    public string? ReleaseNotesUrl { get; init; }
    
    public string? PurchaseUrl { get; init; }
    
    public string? InstallationNotes { get; init; }
    
    public string? Documentations { get; init; }
}