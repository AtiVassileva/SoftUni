using System;
using System.Linq;
using System.Collections.Generic;

namespace EvenTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            var count = int.Parse(Console.ReadLine());
            var numberOccurences = new Dictionary<double, int>();

            for (var i = 0; i < count; i++)
            {
                var currentNum = double.Parse(Console.ReadLine());

                if (!numberOccurences.ContainsKey(currentNum))
                {
                    numberOccurences.Add(currentNum, 0);
                }
                numberOccurences[currentNum]++;
            }

            foreach (var kvp in numberOccurences)
            {
                if (kvp.Value % 2 == 0)
                {
                    Console.WriteLine(kvp.Key);
                }
            }
        }
    }
}