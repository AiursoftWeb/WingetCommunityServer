using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WingetCommunityServer.Models.Database;

public class PackageVersion
{
    [Key]
    public int DatabaseId { get; set; }
    
    public required int PackageId { get; init; }
    [ForeignKey(nameof(PackageId))]
    public Package Package { get; init; } = null!;
    
    // Identical to Package.Id
    
    public required string Version { get; init; }
    
    
    public required string InstallerType { get; init; }
    
    public required string Scope { get; init; }
    
    // TODO: This is an object, not a string.
    // Require further modeling. See https://github.com/microsoft/winget-pkgs/blob/master/manifests/p/Postman/Postman/10.20.0/Postman.Postman.installer.yaml
    public required string InstallModes { get; init; }
    
    // TODO: This is an object, not a string.
    // Require further modeling. See https://github.com/microsoft/winget-pkgs/blob/master/manifests/p/Postman/Postman/10.20.0/Postman.Postman.installer.yaml
    public required string InstallerSwitches { get; init; }
    
    public required string InstallerSuccessCodes { get; init; }
    
    public required string UpgradeBehavior { get; init; }
    
    public required string ProductCode { get; init; }
    
    public required string Protocols { get; init; }
    
    public required string FileExtensions { get; init; }
    
    public required DateTime ReleaseDate { get; init; }
    
    [InverseProperty(nameof(PackageVersionInstaller.PackageVersion))]
    public IEnumerable<PackageVersionInstaller>? Installers { get; set; }
    
    [InverseProperty(nameof(PackageVersionLocale.PackageVersion))]
    public IEnumerable<PackageVersionLocale>? Locales { get; set; }
}