using System;
using System.Linq;

namespace DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            var size = int.Parse(Console.ReadLine());
            var matrix = new int[size, size];

            for (var i = 0; i < size; i++)
            {
                var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (var j = 0; j < size; j++)
                {
                    matrix[i, j] = input[j];
                }
            }
            var primarySum = 0;

            for (var i = 0; i < size; i++)
            {
                primarySum += matrix[i, i];
            }

            var otherSum = 0;
            var index = 0;
            for (var i = size - 1; i >= 0; i--)
            {
                otherSum += matrix[i, index];
                index++;
            }
            Console.WriteLine(Math.Abs(otherSum - primarySum));
        }
    }
}