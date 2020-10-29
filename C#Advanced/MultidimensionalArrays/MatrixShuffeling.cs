using System;
using System.Linq;

namespace MatrixShuffeling
{
    class Program
    {
        static void Main(string[] args)
        {
            var sizes = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var rows = sizes[0];
            var cols = sizes[1];

            var matrix = new string[rows, cols];

            for (var row = 0; row < rows; row++)
            {
                var inputChars = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                for (var col = 0; col < cols; col++)
                {
                    matrix[row, col] = inputChars[col];
                }
            }
            while (true)
            {
                var line = Console.ReadLine();
                if (line == "END")
                {
                    break;
                }
                var commandArgs = line.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (commandArgs[0] == "swap" && commandArgs.Length == 5)
                {
                    var row1 = int.Parse(commandArgs[1]);
                    var col1 = int.Parse(commandArgs[2]);
                    var row2 = int.Parse(commandArgs[3]);
                    var col2 = int.Parse(commandArgs[4]);

                    if (row1 >= 0 && col1 >= 0 && row2 >= 0 && col2 >= 0 && row1 < matrix.GetLength(0) && row2 < matrix.GetLength(0) && col1 < matrix.GetLength(1) && col2 < matrix.GetLength(1))
                    {
                        var firstElement = matrix[row2, col2];
                        var secondElement = matrix[row1, col1];
                        matrix[row1, col1] = firstElement;
                        matrix[row2, col2] = secondElement;

                        for (int row = 0; row < matrix.GetLength(0); row++)
                        {
                            for (int col = 0; col < matrix.GetLength(1); col++)
                            {
                                Console.Write(matrix[row, col] + " ");
                            }
                            Console.WriteLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }
        }
    }
}