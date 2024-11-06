namespace GlowingSystem.Core.DataTransferObjects
{
    public record CustomerForUpdateDto
    {
        public required string CustomerName { get; set; }
    }
}
