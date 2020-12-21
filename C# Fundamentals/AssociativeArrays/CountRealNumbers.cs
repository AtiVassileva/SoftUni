using System;
using System.Linq;
using System.Collections.Generic;

namespace CountRealNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var givenNums = Console.ReadLine().Split().Select(double.Parse).ToArray();
            var counts = new SortedDictionary<double, int>();

            foreach (var item in givenNums)
            {
                if (counts.ContainsKey(item))
                {
                    counts[item]++;
                }
                else
                {
                    counts.Add(item, 1);
                }
            }

            foreach (var item in counts)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}