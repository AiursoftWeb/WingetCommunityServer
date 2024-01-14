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
}