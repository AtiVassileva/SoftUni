using System;
using System.Collections.Generic;

namespace CountCharsInString
{
    class Program
    {
        static void Main(string[] args)
        {
            var histogram = new Dictionary<char, uint>();
            var text = Console.ReadLine();

            for (var i = 0; i < text.Length; i++)
            {
                var current = text[i];

                if (current != ' ')
                {

                    if (!histogram.ContainsKey(current))
                    {
                        histogram[current] = 0;
                    }

                    histogram[current]++;
                }
            }

            foreach (var kvp in histogram)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}