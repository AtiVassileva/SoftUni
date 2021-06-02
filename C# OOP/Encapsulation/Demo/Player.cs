using System;


namespace FootballTeamGenerator
{
    public class Player
    {
        private const int minRange = 0;
        private const int maxRange = 100;


        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        private readonly double sum;

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Name = name;
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;

        }


        public double SkillLevel => this.CalculateSkillLevel();

        public int Shooting
        {
            get => shooting;
            private set
            {
                this.CheckForInvalidParameterValue("Shooting", value);
                shooting = value;
            }
        }

        public int Passing
        {
            get => passing;
            private set
            {
                this.CheckForInvalidParameterValue("Passing", value);
                passing = value;
            }
        }

        public int Dribble
        {
            get => this.dribble;
            private set
            {
                this.CheckForInvalidParameterValue("Dribble", value);
                this.dribble = value;
            }
        }

        public int Sprint
        {
            get => this.sprint;
            private set
            {
                CheckForInvalidParameterValue("Sprint", value);
                this.sprint = value;
            }
        }

        public int Endurance
        {
            get => this.endurance;
            private set
            {
                this.CheckForInvalidParameterValue("Endurance", value);
                endurance = value;
            }
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }
                this.name = value;
            }
        }

        private void CheckForInvalidParameterValue(string parameter, int value)
        {
            if (value < minRange || value > maxRange)
            {
                throw new ArgumentException($"{parameter} should be between {minRange} and {maxRange}.");
            }
        }

        private double CalculateSkillLevel()
        {
            return (this.endurance + this.dribble + this.sprint + this.passing + this.shooting) / 5.0;
        }
    }
}