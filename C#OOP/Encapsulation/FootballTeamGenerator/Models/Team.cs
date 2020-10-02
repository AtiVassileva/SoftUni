using System;
using System.Collections.Generic;
using System.Linq;
using P05.FootballTeamGenerator.Common;

namespace P05.FootballTeamGenerator.Models
{
    public class Team
    {
        private string name;
        private readonly List<Player> players;

        public Team(string name)
        {
            this.Name = name;
            this.players = new List<Player>();
        }

        public string Name { 
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new InvalidOperationException(GlobalConstants.InvalidNameException);
                }
                this.name = value;
            }
        }

        public double Rating => this.CalculateRating();

        public void AddPlayer(Player player)
        {
            this.players.Add(player);
        }

        public void RemovePlayer(string playerName)
        {
            if (this.players.All(p => p.Name != playerName))
            {
                var msg = string.Format(GlobalConstants.MissingPlayerException, playerName, this.Name);

                throw new ArgumentException(msg);
            }

            var player = this.players.First(p => p.Name == playerName);
            this.players.Remove(player);
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.Rating}";
        }

        private double CalculateRating()
        {
            var totalRating = 0.0;

            foreach (var player in this.players)
            {
                totalRating += player.CalculateAverageSkillLevel();
            }

            return Math.Round(totalRating);
        }


    }
}
