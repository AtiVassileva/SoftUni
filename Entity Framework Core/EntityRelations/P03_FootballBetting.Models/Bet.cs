using System;
using P03_FootballBetting.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace P03_FootballBetting.Models
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