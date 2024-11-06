namespace GlowingSystem.Core.DataTransferObjects
{
    public record CustomerDto
    {
        public required Guid Id { get; set; }
        public required string CustomerName { get; set; }
    }
}
