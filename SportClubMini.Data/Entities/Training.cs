using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportsClubMini.Data.Entities
{
    public class Training
    {
        [Key]
        public Guid TrainingId { get; set; }

        [Required]
        [MaxLength(150)]
        public string Title { get; set; } = string.Empty;

        public DateTime StartTime { get; set; }

        [Range(1, int.MaxValue)]
        public int DurationMinutes { get; set; }

        [Range(1, int.MaxValue)]
        public int MaxParticipants { get; set; }

        public Guid TrainerId { get; set; }

        // Navigation properties
        [ForeignKey(nameof(TrainerId))]
        public Trainer Trainer { get; set; } = null!;
    }
}
