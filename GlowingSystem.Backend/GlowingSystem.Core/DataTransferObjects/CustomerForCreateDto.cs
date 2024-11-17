using System.ComponentModel.DataAnnotations;

namespace GlowingSystem.Core.DataTransferObjects
{
    public record CustomerForCreateDto
    {
        [Required(ErrorMessage = "Customer name is required field")]
        public required string CustomerName { get; set; }
    }
}
