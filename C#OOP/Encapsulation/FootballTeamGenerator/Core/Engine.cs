using System;
using System.Collections.Generic;
using System.Linq;
using P05.FootballTeamGenerator.Common;
using P05.FootballTeamGenerator.Models;

namespace P05.FootballTeamGenerator.Core
{
    public class Engine
    {
        private const string EndOfInput = "END";
        private List<Team> allTeams;

        public Engine()
        {
            this.allTeams = new List<Team>();
        }

        public void Run()
        {
            while (true)
            {
                var line = Console.ReadLine();
                if (line == EndOfInput)
                {
                    break;
                }

                try
                {
                    var args = line.Split(";", StringSplitOptions.RemoveEmptyEntries).ToArray();
                    var command = args[0];

                    switch (command)
                    {
                        case "Team":
                            var teamName = args[1];
                            this.allTeams.Add(new Team(teamName));
                            break;
                        case "Add":
                            var currTeamName = args[1];

                            CheckForInvalidTeam(currTeamName);

                            var playerName = args[2];
                            var playerEndurance = double.Parse(args[3]);
                            var playerSprint = double.Parse(args[4]);
                            var playerDribble = double.Parse(args[5]);
                            var playerPassing = double.Parse(args[6]);
                            var playerShooting = double.Parse(args[7]);

                            var currentTeam = allTeams.First(t => t.Name == currTeamName);
                            var player = new Player(playerName, playerEndurance, playerSprint,
                                playerDribble, playerPassing, playerShooting);

                            currentTeam.AddPlayer(player);
                            break;
                        case "Remove":
                            var teamCurrName = args[1];
                            var playerCurrName = args[2];

                            var team = allTeams.First(t => t.Name == teamCurrName);

                            team.RemovePlayer(playerCurrName);
                            break;
                        case "Rating":
                            var currentTeamName = args[1];
                            CheckForInvalidTeam(currentTeamName);

                            var wantedTeam = allTeams.First(x => x.Name == currentTeamName);
                            Console.WriteLine(wantedTeam);
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }

            }
        }

        private void CheckForInvalidTeam(string currTeamName)
        {
            if (this.allTeams.All(x => x.Name != currTeamName))
            {
                var msg = string.Format(GlobalConstants.NonExistingTeamException, currTeamName);
                throw new ArgumentException(msg);
            }
        }
    }
}
