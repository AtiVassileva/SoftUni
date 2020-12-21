using System;
using System.Linq;
using System.Collections.Generic;

namespace OddOccurances
{
    class Program
    {
        static void Main(string[] args)
        {
            var words = Console.ReadLine().Split();
            var counts = new Dictionary<string, int>();

            foreach (var item in words)
            {
                var currWord = item.ToLower();

                if (counts.ContainsKey(currWord))
                {
                    counts[currWord]++;
                }
                else
                {
                    counts.Add(currWord, 1);
                }
            }

            foreach (var item in counts)
            {
                if (item.Value % 2 != 0)
                {
                    Console.Write(item.Key + " ");
                }
            }
        }
    }
}