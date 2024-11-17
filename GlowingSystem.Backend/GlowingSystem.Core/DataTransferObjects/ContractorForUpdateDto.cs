using System.ComponentModel.DataAnnotations;

namespace GlowingSystem.Core.DataTransferObjects
{
    public record ContractorForUpdateDto
    {
        [Required(ErrorMessage = "Contractor name is required field")]
        public required string ContractorName { get; set; }
    }
}
