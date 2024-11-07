namespace GlowingSystem.Core.Models
{
    public class Employee
    {
        public required Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public required bool IsManager { get; set; }
        public List<Project> Projects { get; set; } = new();
    }
}
