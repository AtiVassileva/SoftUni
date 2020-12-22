using System;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Collections;
using System.Globalization;
using System.Collections.Generic;
using System.Text.RegularExpressions;


namespace ConsoleApp
{
    class Program
    {
        static void Main()
        {
            var key = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();
            var currPos = 0;
            string sequence;
            var regex = @"&(?<type>.+)&[^<]*<(?<coord>.+)>";

            while ((sequence = Console.ReadLine()) != "find")
            {
                var keyLength = key.Count;
                var sequenceLength = sequence.Length;
                var sb = new StringBuilder();

                for (var i = keyLength; i < sequenceLength; i++)
                {
                    key.Add(key[currPos]);
                    currPos++;
                }

                for (var i = 0; i < sequenceLength; i++)
                {
                    sb.Append((char)(sequence[i] - key[i]));
                }

                var match = Regex.Match(sb.ToString(), regex);

                if (match.Success)
                {
                    var type = match.Groups["type"].Value;
                    var coord = match.Groups["coord"].Value;
                    Console.WriteLine($"Found {type} at {coord}");
                }
            }
        }
    }
}