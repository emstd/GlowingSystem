namespace GlowingSystem.Core.DataTransferObjects
{
    public record ProjectForUpdateDto
    {
        public required string ProjectName { get; set; }
        public Guid CustomerId { get; set; }
        public Guid ContractorId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int Priority { get; set; }
        public Guid? TeamLeadId { get; set; }
        public List<Guid>? EmployeesIds { get; set; }
    }
}
