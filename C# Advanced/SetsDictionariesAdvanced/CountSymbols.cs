using System;
using System.Collections.Generic;

namespace CountSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().ToCharArray();
            var result = new SortedDictionary<char, int>();

            foreach (var symbol in input)
            {
                if (!result.ContainsKey(symbol))
                {
                    result.Add(symbol, 0);
                }
                result[symbol]++;
            }

            foreach (var kvp in result)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value} time/s");
            }
        }
    }
}