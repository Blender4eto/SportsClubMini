using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsClubMini.Data.Entities
{
    public class SportClub
    {
        [Key]
        public Guid ClubId { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Sport {  get; set; } = string.Empty;

        [Required]
        public string City { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
    }
}
