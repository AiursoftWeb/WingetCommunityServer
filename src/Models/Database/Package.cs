﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WingetCommunityServer.Models.Database;

public class Package
{
    [Key]
    public int DatabaseId { get; set; }
    
    public required string Id { get; init; }
    
    [InverseProperty(nameof(PackageVersion.Package))]
    public IEnumerable<PackageVersion>? Versions { get; set; }
}