namespace SixMinApi.Dtos
{
    public class BeneficiaryReadDto : DependantReadDto
    {
        public string? Relationship { get; set; }
        
        public string? ContactNumber { get; set; }

        public string? Email { get; set; }
    }
}