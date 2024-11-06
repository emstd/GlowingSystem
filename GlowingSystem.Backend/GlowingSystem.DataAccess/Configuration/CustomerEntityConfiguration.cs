using GlowingSystem.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GlowingSystem.DataAccess.Configuration
{
    public class CustomerEntityConfiguration : IEntityTypeConfiguration<CustomerEntity>
    {
        public void Configure(EntityTypeBuilder<CustomerEntity> builder)
        {
            builder.HasData
            (
                new CustomerEntity()
                {
                    Id = new Guid("02ac74f4-5bd6-49e3-ab8e-5c817b665eb9"),
                    CustomerName = "Yanbex"
                },
                new CustomerEntity()
                {
                    Id = new Guid("39156042-6faf-45f3-b0e9-65f0c1b34ecd"),
                    CustomerName = "Goodle"
                },
                new CustomerEntity()
                {
                    Id = new Guid("a3f97ff5-f4e9-48a1-a7eb-d84f0c48c460"),
                    CustomerName = "Ramdler"
                }
            );
        }
    }
}
