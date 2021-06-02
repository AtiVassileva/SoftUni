using System;
using System.Linq;
using System.Collections.Generic;

namespace ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputArr = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            var divider = int.Parse(Console.ReadLine());

            var filter = n => n % divider != 0;

            var remaining = inputArr.Where(filter);
            Console.WriteLine(string.Join(' ', remaining.Reverse()));
        }
    }
}