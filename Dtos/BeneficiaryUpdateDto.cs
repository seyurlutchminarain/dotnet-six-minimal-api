using System.ComponentModel.DataAnnotations;

namespace SixMinApi.Dtos
{
    public class BeneficiaryUpdateDto : DependantUpdateDto
    {
        [Required]
        public string? Relationship { get; set; }
        
        [Required]
        public string? ContactNumber { get; set; }

        [Required]
        public string? Email { get; set; }

    }
}