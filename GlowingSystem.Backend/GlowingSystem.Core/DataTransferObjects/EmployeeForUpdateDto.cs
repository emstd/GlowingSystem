using System.ComponentModel.DataAnnotations;

namespace GlowingSystem.Core.DataTransferObjects
{
    public record EmployeeForUpdateDto
    {
        [Required(ErrorMessage = "First name is required field")]
        public required string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required field")]
        public required string LastName { get; set; }
        public string? Surname { get; set; }

        [Required(ErrorMessage = "Email name is required field")]
        public required string Email { get; set; }
    }
}
