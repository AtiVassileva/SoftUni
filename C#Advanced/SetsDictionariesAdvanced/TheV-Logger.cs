using System;
using System.Linq;
using System.Collections.Generic;

namespace TheV_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            var vlogerFollowers = new Dictionary<string, List<string>>();
            var vlogerFollowing = new Dictionary<string, List<string>>();

            while (true)
            {
                var line = Console.ReadLine();

                if (line == "Statistics")
                {
                    break;
                }

                var input = line.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                var currVlogerName = input[0];
                var currCommand = input[1];

                if (currCommand == "joined" && !vlogerFollowers.ContainsKey(currVlogerName))
                {
                    vlogerFollowers.Add(currVlogerName, new List<string>());
                    vlogerFollowing.Add(currVlogerName, new List<string>());
                }

                if (currCommand == "followed")
                {
                    var personToFollow = input[2];
                    if (vlogerFollowers.ContainsKey(personToFollow) && currVlogerName != personToFollow)
                    {
                        if (personToFollow != currVlogerName && !vlogerFollowers[personToFollow].Contains(currVlogerName) && !vlogerFollowing[currVlogerName].Contains(personToFollow))
                        {
                            vlogerFollowers[personToFollow].Add(currVlogerName);
                            vlogerFollowing[currVlogerName].Add(personToFollow);
                        }
                    }
                }
            }

            var mostFamous = string.Empty;
            var mostFamousCount = 0;

            foreach (var kvp in vlogerFollowers)
            {
                if (kvp.Value.Count > mostFamousCount)
                {
                    mostFamous = kvp.Key;
                    mostFamousCount = kvp.Value.Count;
                }
            }

            Console.WriteLine($"The V-Logger has a total of {vlogerFollowers.Count} vloggers in its logs.");
            Console.WriteLine($"1. {mostFamous} : {vlogerFollowers[mostFamous].Count} followers, {vlogerFollowing[mostFamous].Count} following");

            foreach (var follower in vlogerFollowers[mostFamous].OrderBy(x => x))
            {
                Console.WriteLine($"*  {follower}");
            }

            var counter = 2;
            vlogerFollowers.Remove(mostFamous);

            foreach (var kvp in vlogerFollowers.OrderByDescending(x => x.Value.Count).ThenBy(x => vlogerFollowing[x.Key].Count))
            {
                Console.WriteLine($"{counter}. {kvp.Key} : {kvp.Value.Count} followers, {vlogerFollowing[kvp.Key].Count} following");
                counter++;
            }

        }
    }
}