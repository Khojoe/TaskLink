using System.ComponentModel.DataAnnotations;

namespace TaskLink.Models
{
    public class ProviderProfile
    {
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; } = string.Empty;
        public ApplicationUser? User { get; set; }

        [Required, Display(Name = "Trade / Service")]
        public string Trade { get; set; } = string.Empty;

        [Required, Display(Name = "Bio / Description")]
        [StringLength(500)]
        public string Bio { get; set; } = string.Empty;

        [Required, Phone, Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required, Display(Name = "Location (City / Area)")]
        public string Location { get; set; } = string.Empty;

        [Display(Name = "Years of Experience")]
        [Range(0, 60)]
        public int YearsOfExperience { get; set; }

        public bool IsAvailable { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
