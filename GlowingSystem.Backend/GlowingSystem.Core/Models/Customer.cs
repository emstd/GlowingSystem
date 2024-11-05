namespace GlowingSystem.Core.Models
{
    public class Customer
    {
        public required Guid Id { get; set; }
        public string CompanyName { get; set; } = string.Empty;
    }
}
