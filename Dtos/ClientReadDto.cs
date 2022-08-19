using SixMinApi.Models;

namespace SixMinApi.Dtos
{
    public class ClientReadDto
    {     
        public int UserId { get; set; }

        public string? Title { get; set; }
        public string? FirstName { get; set; }

        public string? LastName { get; set; }
   
        public string? Email { get; set; }

        public string? ContactNumber { get; set; }
    }
}