﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace P03_FootballBetting.Models
{
    public class Position
    {
        public Position()
        {
            this.Players = new HashSet<Player>();
        }
        public int PositionId { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Player> Players { get; set; }
    }
}