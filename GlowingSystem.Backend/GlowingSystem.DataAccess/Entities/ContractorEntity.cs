﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GlowingSystem.DataAccess.Entities
{
    public class ContractorEntity
    {
        public required Guid Id { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [MaxLength(50, ErrorMessage = "Maximum length for the CompanyName is 50 characters.")]
        public required string ContractorName { get; set; }
    }
}