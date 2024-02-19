using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aiursoft.WingetCommunityServer.Database.Models;

public class PackageVersionLocale
{
    [Key]
    public int DatabaseId { get; set; }
    
    public required int PackageVersionId { get; init; }
    [ForeignKey(nameof(PackageVersionId))]
    public PackageVersion PackageVersion { get; init; } = null!;
    
    [MaxLength(256)]
    public required string PackageLocale { get; init; }
    
    [MaxLength(256)]
    public string? Publisher { get; init; }
    
    [MaxLength(2048)]
    public string? PublisherUrl { get; init; }
    
    [MaxLength(2048)]
    public string? PublisherSupportUrl { get; init; }
    
    [MaxLength(2048)]
    public string? PrivacyUrl { get; init; }
    
    [MaxLength(256)]
    public string? Author { get; init; }
    
    [MaxLength(256)]
    public string? PackageName { get; init; }
    
    [MaxLength(256)]
    public string? PackageUrl { get; init; }
    
    [MaxLength(256)]
    public string? License { get; init; }
    
    [MaxLength(2048)]
    public string? LicenseUrl { get; init; }
    
    [MaxLength(2048)]
    public string? CopyRight { get; init; }
    
    [MaxLength(2048)]
    public string? CopyRightUrl { get; init; }
    
    [MaxLength(2048)]
    public string? ShortDescription { get; init; }
    
    [MaxLength(2048)]
    public string? Description { get; init; }
    
    [MaxLength(2048)]
    public string? Moniker { get; init; }
    
    // TODO: This is a list of strings, not a single string.
    [MaxLength(2048)]
    public string? Tags { get; init; }
    
    [MaxLength(2048)]
    public string? ReleaseNotes { get; init; }
    
    [MaxLength(2048)]
    public string? ReleaseNotesUrl { get; init; }
    
    [MaxLength(2048)]
    public string? PurchaseUrl { get; init; }
    
    [MaxLength(2048)]
    public string? InstallationNotes { get; init; }
    
    [MaxLength(2048)]
    public string? Documentations { get; init; }
}