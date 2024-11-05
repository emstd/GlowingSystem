using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GlowingSystem.DataAccess.Entities
{
    public class CompanyBase
    {
        public required Guid Id { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [MaxLength(50, ErrorMessage = "Maximum length for the CompanyName is 50 characters.")]
        public required string CompanyName { get; set; } = string.Empty;
    }
}
