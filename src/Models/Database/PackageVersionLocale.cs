using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WingetCommunityServer.Models.Database;

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
    
    public string? Moniker { get; init; }
    
    // TODO: This is a list of strings, not a single string.
    public string? Tags { get; init; }
    
    public string? ReleaseNotes { get; init; }
    
    public string? ReleaseNotesUrl { get; init; }
    
    public string? PurchaseUrl { get; init; }
    
    public string? InstallationNotes { get; init; }
    
    public string? Documentations { get; init; }
}