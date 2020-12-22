using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace StarEnigma
{
    class Program
    {
        static void Main(string[] args)
        {
            var count = int.Parse(Console.ReadLine());
            var firstPattern = @"[starSTAR]";

            var attacked = new List<string>();
            var destroyed = new List<string>();

            for (var i = 0; i < count; i++)
            {
                var message = Console.ReadLine();
                var matchedLetters = Regex.Matches(message, firstPattern);
                var countMatchedLetters = matchedLetters.Count;

                var newMessage = string.Empty;

                foreach (var letter in message)
                {
                    newMessage += (char)(letter - countMatchedLetters);
                }

                var planetNamePattern = @"@(?<name>[A-Za-z]+)[^\@\-!:>]*:(?<population>[0-9]+)[^\@\-!:>]*!(?<attack>A|D+)![^\@\-!:>]*->(?<soldiers>[0-9]+)";

                var planetArgs = Regex.Match(newMessage, planetNamePattern);

                if (planetArgs.Success)
                {
                    var name = planetArgs.Groups["name"].Value;
                    var type = planetArgs.Groups["attack"].Value;

                    if (type == "A")
                    {
                        attacked.Add(name);
                    }
                    else if (type == "D")
                    {
                        destroyed.Add(name);
                    }
                }
            }

            Console.WriteLine($"Attacked planets: {attacked.Count}");

            foreach (var planet in attacked.OrderBy(p => p))
            {
                Console.WriteLine($"-> {planet}");
            }

            Console.WriteLine($"Destroyed planets: {destroyed.Count}");

            foreach (var planet in destroyed.OrderBy(p => p))
            {
                Console.WriteLine($"-> {planet}");
            }
        }
    }
}