using GlowingSystem.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace GlowingSystem.ContextFactory
{
    public class GlowingSystemDbContextFactory : IDesignTimeDbContextFactory<GlowingSystemDbContext>
    {
        public GlowingSystemDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<GlowingSystemDbContext>()
                .UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    builder => builder.MigrationsAssembly("GlowingSystem"));

            return new GlowingSystemDbContext(builder.Options);
        }
    }
}
