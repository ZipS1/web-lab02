using Microsoft.AspNetCore.Identity;

namespace lab02.Models.Account
{
    public class AppUser : IdentityUser
    {
        public string? FirstName { get; set; }

        public string? MiddleName { get; set; }

        public string? LastName { get; set; }

        public string? Position { get; set; }

        public int? SupplierId { get; set; }

        public Supplier? Supplier { get; set; }
    }
}
