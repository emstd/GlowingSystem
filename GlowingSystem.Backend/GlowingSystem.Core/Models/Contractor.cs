using System.ComponentModel.DataAnnotations;

namespace GlowingSystem.Core.Models
{
    public class Contractor
    {
        public required Guid Id { get; set; }
        public string ContractorName { get; set; } = string.Empty;
    }
}
