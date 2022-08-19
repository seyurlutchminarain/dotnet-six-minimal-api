namespace SixMinApi.Dtos
{
    public class AddressReadDto
    {
        public int AddressId { get; set; }
        
        public string? ComplexBuilding { get; set; }

        public string? StreetAddress { get; set; }

        public string? Suburb { get; set; }

        public string? City { get; set; }

        public int PostalCode { get; set; }

        public string? Country { get; set; }
    }
}