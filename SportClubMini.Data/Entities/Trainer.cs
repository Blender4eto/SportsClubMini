using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportsClubMini.Data.Entities
{
    public class Trainer
    {
        [Key]
        public Guid TrainerId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Phone]
        public string Phone { get; set; } = string.Empty;

        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        public Guid ClubId { get; set; }

        public Guid SportId { get; set; }

        // Navigation properties
        [ForeignKey(nameof(ClubId))]
        public SportClub Club { get; set; } = null!;

        [ForeignKey(nameof(SportId))]
        public Sport Sport { get; set; } = null!;
    }
}
