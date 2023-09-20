using Microsoft.EntityFrameworkCore;

namespace Aiursoft.WingetCommunityServer.Data
{
    public class WingetServerDbContext : DbContext
    {
        public WingetServerDbContext(DbContextOptions<WingetServerDbContext> options) : base(options)
        {
        }
    }
}
