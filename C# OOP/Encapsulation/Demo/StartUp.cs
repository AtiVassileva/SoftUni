using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator
{
    public class Program
    {
        static void Main(string[] args)
        {
            var word = Console.ReadLine();
                   var teamList = new List<Team>();

            while (word != "END")
            {
                try
                {
                    var command = word.Split(";").ToArray();
                    var teamName = command[1];

                    if (command[0] == "Team")
                    {
                        if (teamList.All(t => t.Name != teamName))
                        {
                            var team = new Team(teamName);
                            teamList.Add(team);
                        }

                    }
                    else if (command[0] == "Add")
                    {
                        if (teamList.Any(t => t.Name == teamName))
                        {
                            var playerName = command[2];
                            var endurance = int.Parse(command[3]);
                            var sprint = int.Parse(command[4]);
                            var dribble = int.Parse(command[5]);
                            var passing = int.Parse(command[6]);
                            var shooting = int.Parse(command[7]);

                            var team = teamList.First(t => t.Name == teamName);
                            var player = new Player(playerName, endurance, sprint, dribble, passing, shooting);

                            team.AddPlayer(player);

                        }
                        else
                        {
                            throw new ArgumentException($"Team {teamName} does not exist.");
                        }
                    }

                    else if (command[0] == "Remove")
                    {
                        var playerName = command[2];

                        var currTeam = teamList.FirstOrDefault(x => x.Name == teamName);
                        var currPlayer = currTeam.Players.FirstOrDefault(p => p.Name == playerName);

                        if (currTeam != null && currTeam.Players.Contains(currPlayer))
                        {
                            currTeam.RemovePlayer(currPlayer);
                        }
                        else
                        {
                            throw new ArgumentException($"Player {playerName} is not in {teamName} team.");
                        }
                    }

                    else if (command[0] == "Rating")
                    {
                        var currTeam = teamList.FirstOrDefault(x => x.Name == teamName);

                        if (currTeam != null)
                        {
                            Console.WriteLine($"{teamName} - {currTeam.Rating}");

                        }
                        else
                        {
                            throw new ArgumentException($"Team {teamName} does not exist.");
                        }

                    }

                }
                catch (ArgumentException ae)
                {

                    Console.WriteLine(ae.Message);

                }
                word = Console.ReadLine();
            }
        }
    }
}