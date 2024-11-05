using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GlowingSystem.DataAccess.Entities
{
    public class EmployeeEntity
    {
        public required Guid Id { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [MaxLength(50, ErrorMessage = "Maximum length for the FirstName is 50 characters.")]
        public string FirstName { get; set; } = string.Empty;

        [Column(TypeName = "nvarchar(50)")]
        [MaxLength(50, ErrorMessage = "Maximum length for the LastName is 50 characters.")]
        public string LastName { get; set; } = string.Empty;

        [Column(TypeName = "nvarchar(50)")]
        [MaxLength(50, ErrorMessage = "Maximum length for the Surname is 50 characters.")]
        public string Surname { get; set; } = string.Empty;

        [Column(TypeName = "nvarchar(50)")]
        [MaxLength(50, ErrorMessage = "Maximum length for the Email is 50 characters.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; } = string.Empty;
        public required bool IsManager { get; set; }
        public List<EmployeeProject> EmployeeProject { get; set; } = new();
        public List<ProjectEntity> Projects { get; set; } = new();
    }
}
