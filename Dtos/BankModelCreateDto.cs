using System.ComponentModel.DataAnnotations;

namespace SixMinApi.Dtos
{
    public class BankModelCreateDto
    {
        [Required]
        public string?  BankName { get; set; }

        [Required]
        public string? AccountHolderName { get; set; } 

        [Required]
        public string? AccountNumber { get; set; }

        [Required]
        public string? AccountType { get; set; }

        [Required]
        public string? DebitDate { get; set; }
    }
}