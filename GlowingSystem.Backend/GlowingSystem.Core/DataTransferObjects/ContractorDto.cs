namespace GlowingSystem.Core.DataTransferObjects
{
    public record ContractorDto
    {
        public required Guid Id { get; set; }
        public required string ContractorName { get; set; }
    }
}
