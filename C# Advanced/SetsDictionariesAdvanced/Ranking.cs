using System;
using System.Linq;
using System.Collections.Generic;

namespace Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            var contestPassword = new Dictionary<string, string>();
            var userContestPoints = new Dictionary<string, Dictionary<string, int>>();

            while (true)
            {
                var line = Console.ReadLine();
                if (line == "end of contests")
                {
                    break;
                }

                var input = line.Split(':');
                var contest = input[0];
                var password = input[1];

                if (!contestPassword.ContainsKey(contest))
                {
                    contestPassword.Add(contest, password);
                }
            }

            while (true)
            {
                var line = Console.ReadLine();
                if (line == "end of submissions")
                {
                    break;
                }

                var inputArgs = line.Split("=>").ToArray();
                var currentContest = inputArgs[0];
                var currentPassword = inputArgs[1];
                var currentParticipant = inputArgs[2];
                var currentPoints = int.Parse(inputArgs[3]);

                if (contestPassword.ContainsKey(currentContest) && contestPassword[currentContest] == currentPassword)
                {
                    if (!userContestPoints.ContainsKey(currentParticipant))
                    {
                        userContestPoints.Add(currentParticipant, new Dictionary<string, int>());
                        userContestPoints[currentParticipant].Add(currentContest, currentPoints);
                    }

                    if (userContestPoints.ContainsKey(currentParticipant) && !userContestPoints[currentParticipant].ContainsKey(currentContest))
                    {
                        userContestPoints[currentParticipant].Add(currentContest, currentPoints);
                    }

                    if (userContestPoints.ContainsKey(currentParticipant) && userContestPoints[currentParticipant].ContainsKey(currentContest))
                    {
                        if (currentPoints > userContestPoints[currentParticipant][currentContest])
                        {
                            userContestPoints[currentParticipant][currentContest] = currentPoints;
                        }
                    }
                }
            }

            var bestName = string.Empty;
            var bestPoints = 0;

            foreach (var member in userContestPoints)
            {
                if (userContestPoints[member.Key].Values.Sum() > bestPoints)
                {
                    bestPoints = userContestPoints[member.Key].Values.Sum();
                    bestName = member.Key;
                }
            }

            Console.WriteLine($"Best candidate is {bestName} with total {bestPoints} points.");
            Console.WriteLine("Ranking:");

            foreach (var kvp in userContestPoints.OrderBy(x => x.Key))
            {
                Console.WriteLine(kvp.Key);
                foreach (var kvp1 in userContestPoints[kvp.Key].OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {kvp1.Key} -> {kvp1.Value}");
                }
            }
        }
    }
}