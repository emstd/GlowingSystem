using System.ComponentModel.DataAnnotations;

namespace GlowingSystem.Core.DataTransferObjects
{
    public record CustomerForUpdateDto
    {
        [Required(ErrorMessage = "Customer name is required field")]
        public required string CustomerName { get; set; }
    }
}
