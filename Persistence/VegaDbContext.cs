using Dotnet_Core_EF_Api_Server.Models;
using Microsoft.EntityFrameworkCore;

namespace Dotnet_Core_EF_Api_Server.Persistence
{
    public class VegaDbContext : DbContext 
    {
        public VegaDbContext(DbContextOptions<VegaDbContext> options) : base(options){}

        public DbSet<Make> Make { get; set; }
    }
}