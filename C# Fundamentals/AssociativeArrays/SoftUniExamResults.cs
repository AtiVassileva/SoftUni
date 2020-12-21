using System;
using System.Linq;
using System.Collections.Generic;

namespace SoftUniExamResults
{
    class Program
    {
        static void Main(string[] args)
        {
            var userPoints = new Dictionary<string, int>();
            var languageSubmissions = new Dictionary<string, int>();

            while (true)
            {
                var line = Console.ReadLine();

                if (line == "exam finished")
                {
                    break;
                }

                var input = line.Split('-');

                var name = input[0];
                var language = input[1];

                if (language == "banned")
                {
                    userPoints.Remove(name);
                }
                else
                {
                    var points = int.Parse(input[2]);

                    if (!languageSubmissions.ContainsKey(language))
                    {
                        languageSubmissions.Add(language, 0);
                    }

                    if (userPoints.ContainsKey(name) && userPoints[name] < points)
                    {
                        userPoints[name] = points;
                    }

                    if (!userPoints.ContainsKey(name))
                    {
                        userPoints.Add(name, points);
                    }
                    languageSubmissions[language]++;
                }

            }

            foreach (var kvp in userPoints.OrderByDescending(x => x.Value).ThenBy(y => y.Key))
            {
                Console.WriteLine($"{kvp.Key} | {kvp.Value}");
            }

            foreach (var kvp in languageSubmissions.OrderByDescending(x => x.Value).ThenBy(y => y.Key))
            {
                Console.WriteLine($"{kvp.Key} – {kvp.Value}");
            }
        }
    }
}