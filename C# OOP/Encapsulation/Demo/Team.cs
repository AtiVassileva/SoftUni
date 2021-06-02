using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballTeamGenerator
{
    public class Team
    {
        private string name;
        private List<Player> listPlayer;


        public Team(string name)
        {
            this.Name = name;
            this.listPlayer = new List<Player>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }
                this.name = value;
            }
        }
        //private double rating = 0;
        public int Rating
        {
            get
            {
                if (listPlayer.Count > 0)
                {
                    var result = this.Players.Average(pl => pl.SkillLevel);

                    return (int)Math.Ceiling(result);
                }

                return 0;
            }
        }
        public IReadOnlyCollection<Player> Players =>
            listPlayer.AsReadOnly();

        public void AddPlayer(Player player)
        {
            if (!this.listPlayer.Contains(player))
            {
                listPlayer.Add(player);
            }

        }
        public void RemovePlayer(Player player)
        {
            listPlayer.Remove(player);
        }


    }
}