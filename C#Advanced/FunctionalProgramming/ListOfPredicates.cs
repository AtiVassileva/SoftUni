using System;
using System.Linq;
using System.Collections.Generic;

namespace ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            var upperBoard = int.Parse(Console.ReadLine());
            var dividers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            var validNums = new List<int>();

            for (var i = 1; i <= upperBoard; i++)
            {
                if (DividersInfo(i, dividers))
                {
                    validNums.Add(i);
                }
            }

            Console.WriteLine(string.Join(' ', validNums));
        }

        static bool DividersInfo(int num, List<int> dividers)
        {
            var isValid = true;
            foreach (var divider in dividers)
            {
                if (num % divider != 0)
                {
                    isValid = false;
                }
            }

            return isValid;
        }
    }
}