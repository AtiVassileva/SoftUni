using System;

namespace SymbolInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            var side = int.Parse(Console.ReadLine());
            var matrix = new char[side, side];

            for (var row = 0; row < side; row++)
            {
                var input = Console.ReadLine().ToCharArray();
                for (var col = 0; col < side; col++)
                {
                    matrix[row, col] = input[col];
                }
            }
            var symbol = char.Parse(Console.ReadLine());

            for (var row = 0; row < matrix.GetLength(0); row++)
            {
                for (var col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == symbol)
                    {
                        Console.WriteLine($"({row}, {col})");
                        return;
                    }
                }
            }
            Console.WriteLine($"{symbol} does not occur in the matrix");
        }
    }
}