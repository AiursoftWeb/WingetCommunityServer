using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aiursoft.WingetCommunityServer.Database.Models;

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