using Aiursoft.WingetCommunityServer.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Aiursoft.WingetCommunityServer.Database
{
    public class WingetServerDbContext : DbContext
    {
        public WingetServerDbContext(DbContextOptions<WingetServerDbContext> options) : base(options)
        {
        }
        
        public DbSet<Package> Packages => Set<Package>();
        
        public DbSet<PackageVersion> PackageVersions => Set<PackageVersion>();
        
        public DbSet<PackageVersionLocale> PackageVersionLocales => Set<PackageVersionLocale>();
        
        public DbSet<PackageVersionInstaller> PackageVersionInstallers => Set<PackageVersionInstaller>();
    }
}
