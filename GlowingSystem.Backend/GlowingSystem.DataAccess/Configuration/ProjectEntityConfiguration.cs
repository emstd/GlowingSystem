using GlowingSystem.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GlowingSystem.DataAccess.Configuration
{
    public class ProjectEntityConfiguration : IEntityTypeConfiguration<ProjectEntity>
    {
        public void Configure(EntityTypeBuilder<ProjectEntity> builder)
        {
            builder.HasIndex(p => p.ProjectName).IsUnique(true);
            builder.HasMany(p => p.Employees)
                .WithMany(e => e.Projects)
                .UsingEntity<EmployeeProject>
                (
                    EPbuilder => EPbuilder
                        .HasOne(ep => ep.Employee)
                        .WithMany(e => e.EmployeeProject)
                        .HasForeignKey(ep => ep.EmployeeId),
                    EPBuilder => EPBuilder
                        .HasOne(ep => ep.Project)
                        .WithMany(p => p.EmployeeProject)
                        .HasForeignKey(ep => ep.ProjectId),
                    EPBuilder => EPBuilder
                        .HasKey(ep => new {ep.EmployeeId, ep.ProjectId})
                );
            builder.HasOne(p => p.TeamLead)
                .WithMany()
                .HasForeignKey(p => p.TeamLeadId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasData
            (
                new ProjectEntity()
                {
                    Id = new Guid("0461d05b-fecd-49ee-aa36-d8ae9252f89d"),
                    ProjectName = "miniature-lamp",
                    CustomerId = new Guid("02ac74f4-5bd6-49e3-ab8e-5c817b665eb9"),
                    ContractorId = new Guid("b6d1cdf7-7eea-4524-a524-ff50f40a981b"),
                    StartDate = new DateTime(2024, 3, 23),
                    EndDate = new DateTime(2024, 5, 12),
                    Priority = 0,
                    TeamLeadId = new Guid("36abacc7-45d1-48b5-8b70-30892e24c3d9")
                },
                new ProjectEntity()
                {
                    Id = new Guid("b9f15649-3b79-4773-9ec7-65f249cc9095"),
                    ProjectName = "congenial-waffle",
                    CustomerId = new Guid("39156042-6faf-45f3-b0e9-65f0c1b34ecd"),
                    ContractorId = new Guid("d62ae88b-9c70-4707-8620-1fc44b85ecdf"),
                    StartDate = new DateTime(2024, 4, 20),
                    EndDate = new DateTime(2024, 9, 12),
                    Priority = 0,
                    TeamLeadId = new Guid("ca7744f2-77f0-4cc6-982d-2bb904a43bf3")
                },
                new ProjectEntity()
                {
                    Id = new Guid("a3927bc2-4c76-4c2e-98f2-d06b422cb612"),
                    ProjectName = "congenial-octo-memory",
                    CustomerId = new Guid("a3f97ff5-f4e9-48a1-a7eb-d84f0c48c460"),
                    ContractorId = new Guid("b6d1cdf7-7eea-4524-a524-ff50f40a981b"),
                    StartDate = new DateTime(2024, 3, 23),
                    EndDate = null,
                    Priority = 1,
                    TeamLeadId = new Guid("2d27d4d3-82d9-438f-bdbd-a863eb6e5815")
                },
                new ProjectEntity()
                {
                    Id = new Guid("99711a37-b15e-4f05-82e8-3dfc38b39fe0"),
                    ProjectName = "studious-doodle",
                    CustomerId = new Guid("02ac74f4-5bd6-49e3-ab8e-5c817b665eb9"),
                    ContractorId = new Guid("d62ae88b-9c70-4707-8620-1fc44b85ecdf"),
                    StartDate = new DateTime(2024, 3, 23),
                    EndDate = null,
                    Priority = 1,
                }
            );
        }
    }
}
