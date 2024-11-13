namespace GlowingSystem.Core.DataTransferObjects
{
    public record EmployeeForUpdateDto
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Surname { get; set; }
        public required string Email { get; set; }
    }
}
