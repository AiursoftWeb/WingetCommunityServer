using Microsoft.EntityFrameworkCore;
using WingetCommunityServer.Models.Database;

namespace Aiursoft.WingetCommunityServer.Data
{
    public class WingetServerDbContext : DbContext
    {
        public WingetServerDbContext(DbContextOptions<WingetServerDbContext> options) : base(options)
        {
        }
        
        public DbSet<Package> Packages => Set<Package>();
    }
}
