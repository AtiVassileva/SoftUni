using System;
using P05.FootballTeamGenerator.Common;

namespace P05.FootballTeamGenerator.Models
{
    public class Player
    {
        private const int MinStat = 0;
        private const int MaxStat = 100;

        private const double PlayerStatsCount = 5.0;

        private string _name;
        private double _endurance;
        private double _sprint;
        private double _dribble;
        private double _passing;
        private double _shooting;

        public Player(string name, double endurance, double sprint, double dribble, 
            double passing, double shooting)
        {
            this.Name = name;
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;

        }

        public string Name
        {
            get => this._name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(GlobalConstants.InvalidNameException);
                }

                this._name = value;
            }
        }

        public double Endurance
        {
            get => this._endurance;
            private set
            {
                CheckForInvalidStat(value, "Endurance");

                this._endurance = value;
            }
        }

        public double Sprint
        {
            get => this._sprint;
            private set
            {
                CheckForInvalidStat(value, "Sprint");
                this._sprint = value;
            }
        }

        public double Dribble
        {
            get => this._dribble;
            private set
            {
                CheckForInvalidStat(value, "Dribble");
                this._dribble = value;
            }
        }

        public double Passing
        {
            get => this._passing;
            private set
            {
                CheckForInvalidStat(value, "Passing");
                this._passing = value;
            }
        }

        public double Shooting
        {
            get => this._shooting;
            private set
            {
                CheckForInvalidStat(value, "Shooting");
                this._shooting = value;
            }
        }

        public double CalculateAverageSkillLevel()
        {
            var skillLevel = (this._endurance + this._dribble +
                              this._sprint + this._passing +
                              this._shooting) / PlayerStatsCount;

            return skillLevel;
        }

        private static void CheckForInvalidStat(double value, string parameter)
        {
            if (value < GlobalConstants.MinStat || value > GlobalConstants.MaxStat)
            {
                var msg = string.Format(GlobalConstants.InvalidStatException,
                    parameter, MinStat, MaxStat);
                throw new ArgumentException(msg);
            }
        }
    }
}
