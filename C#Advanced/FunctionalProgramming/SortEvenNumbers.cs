using System;
using System.Linq;

namespace SortEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            var result = input.Where(x => x % 2 == 0).ToArray().OrderBy(x => x);
            Console.WriteLine(string.Join(", ", result));
        }
    }
}