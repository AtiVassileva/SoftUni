using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static BattleCards.Data.DataConstants;

namespace BattleCards.Data.Models
{
    public class Card
    {
        [Key]
        public int Id { get; set; } 

        [Required]
        [MaxLength(CardNameMaxLength)]
        public string Name { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public string Keyword { get; set; }

        [Range(0, int.MaxValue)]
        public int Attack { get; set; }

        [Range(0, int.MaxValue)]
        public int Health { get; set; }

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }

        public ICollection<UserCard> Users { get; set; }
        = new HashSet<UserCard>();
    }
}
