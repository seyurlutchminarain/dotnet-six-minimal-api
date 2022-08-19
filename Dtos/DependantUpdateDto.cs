using System.ComponentModel.DataAnnotations;

namespace SixMinApi.Dtos
{
    public class DependantUpdateDto
    {
        [Required]
        public string? Title { get; set; }

        [Required]
        public string? FirstName { get; set; }

        [Required]
        public string? LastName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public double CoverAmount { get; set; }
    }
}