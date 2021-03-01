﻿using System;
using System.ComponentModel.DataAnnotations;
using P03_FootballBetting.Data.Models.Enums;

namespace P03_FootballBetting.Data.Models
{
    public class Bet
    {
        public int BetId { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public Prediction Prediction { get; set; }

        public DateTime DateTime { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public int GameId { get; set; }

        public Game Game { get; set; }
    }
}