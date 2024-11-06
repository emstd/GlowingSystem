namespace GlowingSystem.Core.DataTransferObjects
{
    public record ContractorDto
    {
        public required Guid Id { get; set; }
        public string CotnractorName { get; set; } = string.Empty;
    }
}
