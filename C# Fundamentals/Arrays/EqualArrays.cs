using System;
using System.Linq;

namespace EqualArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            var arrayFirst = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var arraySecond = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var sum = 0;
            var areEqual = false;

            for (var i = 0; i < arrayFirst.Length; i++)
            {
                if (arrayFirst[i] == arraySecond[i])
                {
                    sum += arrayFirst[i];
                    areEqual = true;
                }
                else
                {
                    areEqual = false;
                    Console.WriteLine($"Arrays are not identical. Found difference at {i} index");
                    break;
                }
            }
            if (areEqual == true)
            {
                Console.WriteLine($"Arrays are identical. Sum: {sum}");
            }
        }
    }
}