using System;
using System.Linq;
using System.Collections.Generic;

namespace PeriodicTable
{
    class Program
    {
        static void Main(string[] args)
        {
            var count = int.Parse(Console.ReadLine());
            var uniqueElements = new SortedSet<string>();

            for (var i = 0; i < count; i++)
            {
                var elements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                
                foreach (var item in elements)
                {
                    uniqueElements.Add(item);
                }
            }

            foreach (var element in uniqueElements)
            {
                Console.Write(element + " ");
            }
        }
    }
}