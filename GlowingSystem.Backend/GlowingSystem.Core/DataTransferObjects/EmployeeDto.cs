namespace GlowingSystem.Core.DataTransferObjects
{
    public record EmployeeDto
    {
        public required Guid Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Surname { get; set; }
        public required string Email { get; set; }
        public required bool IsManager { get; set; }
        public List<Guid>? Projects { get; set; }
    }
}
