using System.ComponentModel.DataAnnotations;

namespace SixMinApi.Dtos
{
    public class AddressUpdateDto
    {
        [Required]
        public string? ComplexBuilding { get; set; }

        [Required]
        public string? StreetAddress { get; set; }

        [Required]
        public string? Suburb { get; set; }

        [Required]
        public string? City { get; set; }

        [Required]
        public int PostalCode { get; set; }

        [Required]
        public string? Country { get; set; }   
    }
}