namespace GlowingSystem.Core.DataTransferObjects
{
    public record EmployeeForCreateDto
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public string? Surname { get; set; }
        public required string Email { get; set; }
        public required bool IsManager { get; set; }
    }
}
