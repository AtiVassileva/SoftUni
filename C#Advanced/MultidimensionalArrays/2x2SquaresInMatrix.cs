using System;
using System.Collections.Generic;
using System.Linq;

namespace _2x2SquaresInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            var sizes = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            var rows = sizes[0];
            var cols = sizes[1];

            var matrix = new char[rows, cols];

            for (var row = 0; row < rows; row++)
            {
                var inputChars = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = inputChars[col];
                }
            }
            var counter = 0;

            for (var row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    var firstElement = matrix[row, col];
                    var secondElement = matrix[row + 1, col];
                    var thirdElement = matrix[row, col + 1];
                    var fourthElement = matrix[row + 1, col + 1];
                    if (firstElement == secondElement && firstElement == thirdElement && firstElement == fourthElement)
                    {
                        counter++;
                    }

                }
            }
            Console.WriteLine(counter);
        }
    }
}