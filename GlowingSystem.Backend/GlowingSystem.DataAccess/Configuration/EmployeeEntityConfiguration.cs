using GlowingSystem.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GlowingSystem.DataAccess.Configuration
{
    public class EmployeeEntityConfiguration : IEntityTypeConfiguration<EmployeeEntity>
    {
        public void Configure(EntityTypeBuilder<EmployeeEntity> builder)
        {
            builder.HasData
            (
                new EmployeeEntity()
                {
                    Id = new Guid("36abacc7-45d1-48b5-8b70-30892e24c3d9"),
                    FirstName = "Петр",
                    LastName = "Петров",
                    Surname = "Петрович",
                    Email = "petr@gmail.com",
                    IsManager = true
                },
                new EmployeeEntity()
                {
                    Id = new Guid("ca7744f2-77f0-4cc6-982d-2bb904a43bf3"),
                    FirstName = "Иван",
                    LastName = "Иванов",
                    Surname = "Иванович",
                    Email = "ivan@gmail.com",
                    IsManager = true
                },
                new EmployeeEntity()
                {
                    Id = new Guid("2d27d4d3-82d9-438f-bdbd-a863eb6e5815"),
                    FirstName = "Андрей",
                    LastName = "Андреев",
                    Surname = "Андреевич",
                    Email = "andrey@gmail.com",
                    IsManager = false
                },
                new EmployeeEntity()
                {
                    Id = new Guid("d0a926b8-8272-4e91-95de-2ed54dc14889"),
                    FirstName = "Алексей",
                    LastName = "Алексеев",
                    Surname = "Алексеевич",
                    Email = "alex@gmail.com",
                    IsManager = false
                }
            );
        }
    }
}
