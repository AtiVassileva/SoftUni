﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace P03_FootballBetting.Models
{
    public class Town
    {
        public Town()
        {
            this.Teams = new HashSet<Team>();
        }
        public int TownId { get; set; }

        [Required]
        public string Name { get; set; }

        public int CountryId { get; set; }

        public Country Country { get; set; }

        public ICollection<Team> Teams { get; set; }
    }
}