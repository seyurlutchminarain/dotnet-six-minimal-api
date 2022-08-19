namespace SixMinApi.Dtos
{
    public class BankModelUpdateDto
    {
        public string?  BankName { get; set; }

        public string? AccountHolderName { get; set; } 

        public string? AccountNumber { get; set; }

        public string? AccountType { get; set; }

        public string? DebitDate { get; set; }
    }
}