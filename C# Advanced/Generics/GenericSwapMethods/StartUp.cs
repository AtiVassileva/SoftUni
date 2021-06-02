using System;
using System.Linq;
using System.Collections.Generic;

namespace GenericSwapMethods
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var count = int.Parse(Console.ReadLine());
            var integers = new List<int>();

            for (var i = 0; i < count; i++)
            {
                var number = int.Parse(Console.ReadLine());
                integers.Add(number);
            }

            var indexesToSwap = Console.ReadLine().
                Split(' ', StringSplitOptions.RemoveEmptyEntries).
                Select(int.Parse)
                .ToArray();

            var firstIndex = indexesToSwap[0];
            var secondIndex = indexesToSwap[1];

            var res = new Swapper<int>(integers);

            res.Swap(firstIndex, secondIndex);

            Console.WriteLine(res);
        }
    }
}