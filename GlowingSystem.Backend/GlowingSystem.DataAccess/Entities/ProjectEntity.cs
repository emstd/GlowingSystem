using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GlowingSystem.DataAccess.Entities
{
    public class ProjectEntity
    {
        public Guid Id { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [MaxLength(50, ErrorMessage = "Maximum length for the ProjectName is 50 characters.")]
        public required string ProjectName { get; set; }
        public CustomerEntity? Customer { get; set; }
        public Guid CustomerId { get; set; }
        public ContractorEntity? Contractor { get; set; }
        public Guid ContractorId { get; set; }

        [Column(TypeName = "DATE")]
        public DateTime StartDate { get; set; }

        [Column(TypeName = "DATE")]
        public DateTime? EndDate { get; set; }
        public int Priority { get; set; }
        public List<EmployeeProject> EmployeeProject { get; set; } = new();
        public List<EmployeeEntity> Employees { get; set; } = new();
    }
}
