using System;
using System.Linq;
using System.Collections.Generic;

namespace Sets_of_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            var sizes = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var firstParameter = sizes[0];
            var secondParameter = sizes[1];

            var firstSet = new HashSet<int>();
            var secondSet = new HashSet<int>();

            for (var i = 0; i < firstParameter; i++)
            {
                var number = int.Parse(Console.ReadLine());
                firstSet.Add(number);
            }

            for (var i = 0; i < secondParameter; i++)
            {
                var number = int.Parse(Console.ReadLine());
                secondSet.Add(number);
            }

            foreach (var item in firstSet)
            {
                if (secondSet.Contains(item))
                {
                    Console.Write(item + " ");
                }
            }
        }
    }
}