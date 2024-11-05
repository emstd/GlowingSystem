using GlowingSystem.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GlowingSystem.DataAccess.Configuration
{
    public class ContractorEntityConfiguration : IEntityTypeConfiguration<ContractorEntity>
    {
        public void Configure(EntityTypeBuilder<ContractorEntity> builder)
        {
            builder.HasData
            (
                new ContractorEntity()
                {
                    Id = new Guid("b6d1cdf7-7eea-4524-a524-ff50f40a981b"),
                    CompanyName = "GenialSolutions"
                },
                new ContractorEntity()
                {
                    Id = new Guid("d62ae88b-9c70-4707-8620-1fc44b85ecdf"),
                    CompanyName = "VeryFastSolutions"
                }
            );
        }
    }
}
