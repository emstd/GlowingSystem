using System.ComponentModel.DataAnnotations;

namespace GlowingSystem.DataAccess.Etnities
{
    public class EmployeeEntity
    {
        public required int Id { get; set; }

        [MaxLength(50, ErrorMessage = "Maximum length for the FirstName is 50 characters.")]
        public string FirstName { get; set; } = string.Empty;

        [MaxLength(50, ErrorMessage = "Maximum length for the LastName is 50 characters.")]
        public string LastName { get; set; } = string.Empty;

        [MaxLength(50, ErrorMessage = "Maximum length for the Surname is 50 characters.")]
        public string Surname { get; set; } = string.Empty;

        [MaxLength(50, ErrorMessage = "Maximum length for the Email is 50 characters.")]
        public string Email { get; set; } = string.Empty;
        public List<ProjectEntity>? Projects { get; set; }
        public required bool IsManager { get; set; }
    }
}
