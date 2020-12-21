using System;
using System.Linq;
using System.Collections.Generic;

namespace CountSameValuesInArray
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();

            var dictionary = new Dictionary<double, int>();

            for (var i = 0; i < numbers.Length; i++)
            {
                if (!dictionary.ContainsKey(numbers[i]))
                {
                    dictionary.Add(numbers[i], 1);
                }
                else
                {
                    dictionary[numbers[i]]++;
                }
            }

            foreach (var kvp in dictionary)
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value} times");
            }
        }
    }
}