namespace lab02.Models
{
    public class Supplier
    {
        public int SupplierId { get; set; }

        public required string FullName { get; set; }

        public string? ShortName { get; set; }

        public string? LegalAddress { get; set; }

        public string? PhoneNumber { get; set; }

        public string? DirectorName { get; set; }
    }
}
