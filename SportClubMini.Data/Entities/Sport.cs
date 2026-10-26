using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace SportsClubMini.Data.Entities
{
    [Index(nameof(Name), IsUnique = true)]
    public class Sport
    {
        [Key]
        public Guid SportId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
    }
}
