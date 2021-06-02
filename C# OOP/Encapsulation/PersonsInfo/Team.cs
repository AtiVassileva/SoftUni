using System.Collections.Generic;

namespace PersonsInfo
{
    public class Team
    {
        private string name;
        private readonly List<Person> _firstTeam;
        private readonly List<Person> _reserveTeam;

        public Team(string name)
        {
            this.Name = name;
            this._firstTeam = new List<Person>();
            this._reserveTeam = new List<Person>();
        }

        public string Name
        {
            get => this.name;
            private set { this.name = value; }
        }

        public IReadOnlyList<Person> FirstTeam => this._firstTeam;
        public IReadOnlyList<Person> ReserveTeam => this._reserveTeam;

        public void AddPlayer(Person player)
        {
            if (player.Age < 40)
            {
                this._firstTeam.Add(player);
            }
            else
            {
                this._reserveTeam.Add(player);
            }
        }

    }
}
