using System.ComponentModel.DataAnnotations;

namespace SixMinApi.Models
{
    public class BankAccountModel
    {
        [Key]
        public int BankId { get; set; }
        
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