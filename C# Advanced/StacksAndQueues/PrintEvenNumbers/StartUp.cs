using System;
using System.Linq;
using System.Collections.Generic;

namespace PrintEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            Console.WriteLine(string.Join(", ", numbers.Where(x => x % 2 == 0)));
        }
    }
}