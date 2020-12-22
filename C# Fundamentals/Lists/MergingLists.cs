using System;
using System.Linq;
using System.Collections.Generic;

namespace MergingLists
{
    class Program
    {
        static void Main(string[] args)
        {
            var first = Console.ReadLine().Split().Select(int.Parse).ToList();
            var second = Console.ReadLine().Split().Select(int.Parse).ToList();
            var newList = new List<int>();
            var biggerLength = Math.Max(first.Count, second.Count);

            for (var i = 0; i < biggerLength; i++)
            {
                if (i < first.Count)
                {
                    newList.Add(first[i]);
                }
                if (i < second.Count)
                {
                    newList.Add(second[i]);
                }
            }

            Console.WriteLine(string.Join(" ", newList));
        }
    }
}