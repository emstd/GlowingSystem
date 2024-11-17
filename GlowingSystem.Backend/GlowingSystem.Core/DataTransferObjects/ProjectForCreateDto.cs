using System.ComponentModel.DataAnnotations;

namespace GlowingSystem.Core.DataTransferObjects
{
    public record ProjectForCreateDto
    {
        [Required(ErrorMessage = "Project name is required field")]
        public string ProjectName { get; set; }
        public Guid CustomerId { get; set; }
        public Guid ContractorId { get; set; }
        [Required(ErrorMessage = "StartDate is required field")]
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        [Required(ErrorMessage = "Priority is required field")]
        public int Priority { get; set; }
        public Guid? TeamLeadId { get; set; }
        public List<Guid>? EmployeesIds { get; set; }
    }
}
