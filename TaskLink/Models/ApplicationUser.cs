using Microsoft.AspNetCore.Identity;

namespace TaskLink.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; } = string.Empty;
        public string Role { get; set; } = "Customer"; // "Provider" or "Customer"

        // Navigation: a user may have one provider profile
        public ProviderProfile? ProviderProfile { get; set; }
    }
}
