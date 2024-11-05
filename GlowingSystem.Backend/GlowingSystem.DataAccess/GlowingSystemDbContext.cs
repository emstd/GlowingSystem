using GlowingSystem.DataAccess.Etnities;
using Microsoft.EntityFrameworkCore;

namespace GlowingSystem.DataAccess
{
    public class GlowingSystemDbContext : DbContext
    {
        public GlowingSystemDbContext(DbContextOptions options) : base(options) { }

        public DbSet<ProjectEntity> Projects { get; set; }
        public DbSet<EmployeeEntity> Employees { get; set; }
        public DbSet<CustomerEntity> Customers { get; set; }
        public DbSet<ContractorEntity> Contractors { get; set; }
    }
}
