namespace GlowingSystem.Core.Models
{
    public class Customer
    {
        public required Guid Id { get; set; }
        public string CustomerName { get; set; } = string.Empty;
    }
}
