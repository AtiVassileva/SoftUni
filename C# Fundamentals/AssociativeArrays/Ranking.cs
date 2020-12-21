using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            var contestAndPassword = new Dictionary<string, string>();
            var nameAndContesstWithPoints = new SortedDictionary<string, Dictionary<string, int>>();
            var inputContest = string.Empty;
            var separator = { "=>" };

            while ((inputContest = Console.ReadLine()) != "end of contests")
            {
                var str = inputContest.Split(':');
                var contest = str[0];
                var password = str[1];
                contestAndPassword.Add(contest, password);
            }

            var inputCollection = string.Empty;

            while ((inputCollection = Console.ReadLine()) != "end of submissions")
            {
                var str2 = inputCollection.Split(separator, StringSplitOptions.None);
                var contestFromCollection = str2[0];
                var passwordFromCollection = str2[1];
                var nameCollection = str2[2];
                var pointFromCollection = int.Parse(str2[3]);

                if (contestAndPassword.ContainsKey(contestFromCollection)
                    && contestAndPassword.ContainsValue(passwordFromCollection))
                {
                    if (nameAndContesstWithPoints.ContainsKey(nameCollection) == false)
                    {
                        nameAndContesstWithPoints.Add(nameCollection, new Dictionary<string, int>());
                        nameAndContesstWithPoints[nameCollection].Add(contestFromCollection, pointFromCollection);
                    }
                    if (nameAndContesstWithPoints[nameCollection].ContainsKey(contestFromCollection))
                    {
                        if (nameAndContesstWithPoints[nameCollection][contestFromCollection] < pointFromCollection)
                        {
                            nameAndContesstWithPoints[nameCollection][contestFromCollection] = pointFromCollection;
                        }
                    }
                    else
                    {
                        nameAndContesstWithPoints[nameCollection].Add(contestFromCollection, pointFromCollection);
                    }
                }
            }

            var usernameTotalPoints = new Dictionary<string, int>();

            foreach (var kvp in nameAndContesstWithPoints)
            {
                usernameTotalPoints[kvp.Key] = kvp.Value.Values.Sum();
            }

            var bestName = usernameTotalPoints
                .Keys
                .Max();
            var bestPoints = usernameTotalPoints
                .Values
                .Max();

            foreach (var kvp in usernameTotalPoints)
            {
                if (kvp.Value == bestPoints)
                {
                    Console.WriteLine($"Best candidate is {kvp.Key} with total {kvp.Value} points.");

                }
            }
            Console.WriteLine("Ranking:");

            foreach (var name in nameAndContesstWithPoints)
            {
                var dict = name.Value;
                dict = dict.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
                Console.WriteLine("{0}", name.Key);

                foreach (var kvp in dict)
                {
                    Console.WriteLine("#  {0} -> {1}", kvp.Key, kvp.Value);
                }
            }
        }
    }
}