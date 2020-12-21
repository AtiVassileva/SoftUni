using System;
using System.Collections.Generic;
using System.Linq;

namespace Judge
{
    class Program
    {
        static void Main(string[] args)
        {
            var contestUserPoints = new Dictionary<string, Dictionary<string, int>>();
            var userPoints = new Dictionary<string, int>();
            var allPointsForUser = new Dictionary<string, int>();

            while (true)
            {
                var line = Console.ReadLine();
                if (line == "no more time")
                {
                    break;
                }

                var input = line.Split(" -> ");
                var user = input[0];
                var contest = input[1];
                var points = int.Parse(input[2]);

                if (!contestUserPoints.ContainsKey(contest))
                {
                    contestUserPoints.Add(contest, new Dictionary<string, int>());

                }
                if (contestUserPoints[contest].ContainsKey(user) && points > userPoints[user])
                {
                    userPoints[user] = points;
                    goto Foo;
                }
                if (!contestUserPoints[contest].ContainsKey(user))
                {
                    contestUserPoints[contest].Add(user, points);
                }

                if (!userPoints.ContainsKey(user))
                {
                    userPoints.Add(user, points);
                }
                else
                {
                    userPoints[user] += points;
                }

            Foo:;
            }

            foreach (var kvp in contestUserPoints)
            {
                Console.WriteLine($"{kvp.Key}: {contestUserPoints[kvp.Key].Count} participants");
                var pos = 1;
                foreach (var kvp1 in contestUserPoints[kvp.Key].OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                {
                    Console.WriteLine($"{pos}. {kvp1.Key} <::> {kvp1.Value}");
                    pos++;
                }

            }

            Console.WriteLine("Individual standings:");

            var position = 1;
            foreach (var kvp in userPoints.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{position}. {kvp.Key} -> {kvp.Value}");
                position++;
            }
        }
    }
}