using System;
using System.Linq;

namespace CustomMinFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            var minNum = (arr) =>
            {
                var minValue = int.MaxValue;

                foreach (var num in arr)
                {
                    if (num < minValue)
                    {
                        minValue = num;
                    }
                }

                return minValue;
            };

            var input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Console.WriteLine(minNum(input));
        }
    }
}