namespace GlowingSystem.Core.DataTransferObjects
{
    public record CustomerDto
    {
        public required Guid Id { get; set; }
        public string CustomerName { get; set; } = string.Empty;
    }
}
