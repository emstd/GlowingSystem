using System.ComponentModel.DataAnnotations;

namespace GlowingSystem.DataAccess.Etnities
{
    public class ProjectEntity
    {
        public int Id { get; set; }

        [MaxLength(50, ErrorMessage = "Maximum length for the ProjectName is 50 characters.")]
        public required string ProjectName { get; set; }
        public int CustomerId { get; set; }
        public int ContractorId { get; set; }
        public List<EmployeeEntity>? Employees { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }
        public int Priority { get; set; }
    }
}
