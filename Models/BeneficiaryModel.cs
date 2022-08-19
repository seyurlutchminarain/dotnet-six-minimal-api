using System.ComponentModel.DataAnnotations;

namespace SixMinApi.Models
{
    public class BeneficiaryModel : DependantModel
    {
        [Required]
        public string? Relationship { get; set; }
        
        [Required]
        public string? ContactNumber { get; set; }

        [Required]
        public string? Email { get; set; }
    }

}