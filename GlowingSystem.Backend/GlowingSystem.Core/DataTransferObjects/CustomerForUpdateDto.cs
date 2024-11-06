namespace GlowingSystem.Core.DataTransferObjects
{
    public record CustomerForUpdateDto
    {
        public string CustomerName { get; set; } = string.Empty;
    }
}
