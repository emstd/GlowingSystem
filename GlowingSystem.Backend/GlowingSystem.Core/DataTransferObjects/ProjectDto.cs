namespace GlowingSystem.Core.DataTransferObjects
{
    public record ProjectDto
    {
        public Guid Id { get; set; }
        public required string ProjectName { get; set; }
        public CustomerDto Customer { get; set; }
        public ContractorDto Contractor { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int Priority { get; set; }
        public List<EmployeeDto>? Employees { get; set; }
    }
}
