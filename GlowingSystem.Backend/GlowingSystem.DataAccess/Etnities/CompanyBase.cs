using System.ComponentModel.DataAnnotations;

namespace GlowingSystem.DataAccess.Etnities
{
    public class CompanyBase
    {
        public required int Id { get; set; }

        [MaxLength(50, ErrorMessage = "Maximum length for the CompanyName is 50 characters.")]
        public required string CompanyName { get; set; } = string.Empty;
    }
}
