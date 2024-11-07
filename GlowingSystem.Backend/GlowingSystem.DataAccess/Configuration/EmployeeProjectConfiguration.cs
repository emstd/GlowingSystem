using GlowingSystem.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GlowingSystem.DataAccess.Configuration
{
    public class EmployeeProjectConfiguration : IEntityTypeConfiguration<EmployeeProject>
    {
        public void Configure(EntityTypeBuilder<EmployeeProject> builder)
        {
            builder.HasData
            (
                new EmployeeProject()
                {
                    ProjectId = new Guid("0461d05b-fecd-49ee-aa36-d8ae9252f89d"),
                    EmployeeId = new Guid("36abacc7-45d1-48b5-8b70-30892e24c3d9")
                },
                new EmployeeProject()
                {
                    ProjectId = new Guid("0461d05b-fecd-49ee-aa36-d8ae9252f89d"),
                    EmployeeId = new Guid("2d27d4d3-82d9-438f-bdbd-a863eb6e5815")
                },

                new EmployeeProject()
                {
                    ProjectId = new Guid("b9f15649-3b79-4773-9ec7-65f249cc9095"),
                    EmployeeId = new Guid("ca7744f2-77f0-4cc6-982d-2bb904a43bf3")
                },
                new EmployeeProject()
                {
                    ProjectId = new Guid("b9f15649-3b79-4773-9ec7-65f249cc9095"),
                    EmployeeId = new Guid("d0a926b8-8272-4e91-95de-2ed54dc14889")
                },

                new EmployeeProject()
                {
                    ProjectId = new Guid("a3927bc2-4c76-4c2e-98f2-d06b422cb612"),
                    EmployeeId = new Guid("36abacc7-45d1-48b5-8b70-30892e24c3d9")
                },
                new EmployeeProject()
                {
                    ProjectId = new Guid("a3927bc2-4c76-4c2e-98f2-d06b422cb612"),
                    EmployeeId = new Guid("d0a926b8-8272-4e91-95de-2ed54dc14889")
                },

                new EmployeeProject()
                {
                    ProjectId = new Guid("99711a37-b15e-4f05-82e8-3dfc38b39fe0"),
                    EmployeeId = new Guid("36abacc7-45d1-48b5-8b70-30892e24c3d9")
                }
            );
        }
    }
}
