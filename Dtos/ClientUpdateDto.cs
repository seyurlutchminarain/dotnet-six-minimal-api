using System.ComponentModel.DataAnnotations;
using SixMinApi.Models;

namespace SixMinApi.Dtos
{
    public class ClientUpdateDto
    {
        [Required]
        public string? Title { get; set; }

        [Required]
        public string? FirstName { get; set; }

        [Required]
        public string? LastName { get; set; }

        [Required]
        public string? Email { get; set; }

        [Required]
        public string? ContactNumber{ get; set; }

        [Required]
        public AddressModel? ResidentialAddress { get; set; }

        [Required]
        public List<DependantModel>? Dependents { get; set; }

        [Required]
        public List<BeneficiaryModel>? Beneficiaries { get; set; }

        [Required]
        public BankAccountModel? BankAccount { get; set; }
    }
}