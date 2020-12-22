using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Race
{
    class Program
    {
        static void Main(string[] args)
        {
            var participants = Console.ReadLine().Split(", ").ToList();
            var namePoints = new Dictionary<string, double>();

            while (true)
            {
                var info = Console.ReadLine();
                if (info == "end of race")
                {
                    break;
                }

                var firstPattern = @"[A-Za-z]";
                var secondPatern = @"[0-9]";

                var nameMatches = Regex.Matches(info, firstPattern);
                var name = string.Empty;

                foreach (var letter in nameMatches)
                {
                    name += letter.ToString();
                }

                var pointsMatched = Regex.Matches(info, secondPatern);
                var totalSum = 0;

                foreach (var num in pointsMatched)
                {
                    totalSum += double.Parse(num.Value);
                }

                if (participants.Contains(name))
                {
                    if (!namePoints.ContainsKey(name))
                    {
                        namePoints.Add(name, 0);
                    }

                    namePoints[name] += totalSum;
                }
            }

            var count = 0;

            foreach (var kvp in namePoints.OrderByDescending(x => x.Value))
            {
                if (count == 0)
                {
                    Console.WriteLine($"1st place: {kvp.Key}");
                }
                else if (count == 1)
                {
                    Console.WriteLine($"2nd place: {kvp.Key}");
                }
                else
                {
                    Console.WriteLine($"3rd place: {kvp.Key}");
                    break;
                }
                count++;
            }
        }
    }
}