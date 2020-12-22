using System;
using System.Linq;
using System.Collections.Generic;

namespace TeamworkProject
{
    class Program
    {
        static void Main(string[] args)
        {
            var count = int.Parse(Console.ReadLine());
            var allTeams = new List<Team>();

            for (var i = 0; i < count; i++)
            {
                var input = Console.ReadLine().Split('-');
                var creator = input[0];
                var name = input[1];

                var existingTeam = allTeams.Find(t => t.TeamName == name);
                var existingTeamCreator = allTeams.Find(t => t.Creator == creator);

                if (existingTeam != null)
                {
                    Console.WriteLine($"Team {name} was already created!");
                    continue;
                }

                if (existingTeamCreator != null)
                {
                    Console.WriteLine($"{creator} cannot create another team!");
                    continue;
                }

                var myTeam = new Team(input[0], input[1]);
                allTeams.Add(myTeam);
                Console.WriteLine($"Team {myTeam.TeamName} has been created by {myTeam.Creator}!");
            }

            var line = Console.ReadLine();

            while (line != "end of assignment")
            {
                var tokens = line.Split("->");
                var member = tokens[0];
                var teamName = tokens[1];

                var currentTeam = allTeams.Find(t => t.TeamName == teamName);
                var currentMember = allTeams.Find(t => t.TeamMembers.Contains(member) || t.Creator == member);

                if (currentTeam == null)
                {
                    Console.WriteLine($"Team {teamName} does not exist!");
                    line = Console.ReadLine();
                    continue;
                }

                if (currentMember != null)
                {
                    Console.WriteLine($"Member {member} cannot join team {teamName}!");
                    line = Console.ReadLine();
                    continue;
                }

                currentTeam.TeamMembers.Add(member);
                line = Console.ReadLine();
            }

            var disbandedTeams = allTeams.Where(a => a.TeamMembers.Count == 0).OrderBy(a => a.TeamName).Select(a => a.TeamName).ToList();
            allTeams.RemoveAll(t => t.TeamMembers.Count == 0);
            var sortedTeams =
                allTeams.OrderByDescending(t => t.TeamMembers.Count).
                    ThenBy(t => t.TeamName).ToList();

            foreach (var team in sortedTeams)
            {
                Console.WriteLine(team.ToString());
            }

            Console.WriteLine("Teams to disband:");

            foreach (var team in disbandedTeams)
            {
                Console.WriteLine(team.ToString());
            }
        }

        class Team
        {
            public Team(string creator, string teamName)
            {
                this.Creator = creator;
                this.TeamName = teamName;
                this.TeamMembers = new List<string>();
            }

            public string Creator { get; set; }
            public string TeamName { get; set; }
            public List<string> TeamMembers = new List<string>();

            public override string ToString()
            {
                var sortedMembers = this.TeamMembers.OrderBy(a => a).ToList();
                var output = $"{TeamName}\n";
                output += $"- {this.Creator}\n";

                for (int i = 0; i < sortedMembers.Count; i++)
                {
                    output += $"-- {sortedMembers[i]}\n";
                }
                return output.TrimEnd();
            }
        }
    }
}