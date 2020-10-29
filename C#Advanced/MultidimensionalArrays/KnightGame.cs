using System;

namespace KnightGame
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
            var totalHorsesCount = 0;

            while (true)
            {
                var maxCount = int.MinValue;
                var knightRow = 0;
                var knightCol = 0;

                for (var row = 0; row < matrix.GetLength(0); row++)
                {
                    for (var col = 0; col < matrix.GetLength(1); col++)
                    {
                        var currentCount = 0;
                        if (matrix[row, col] == 'K')
                        {
                            if (IsInside(matrix, row - 2, col + 1) && matrix[row - 2, col + 1] == 'K')
                            {
                                currentCount++;
                            }
                            if (IsInside(matrix, row - 2, col - 1) && matrix[row - 2, col - 1] == 'K')
                            {
                                currentCount++;
                            }
                            if (IsInside(matrix, row + 2, col + 1) && matrix[row + 2, col + 1] == 'K')
                            {
                                currentCount++;
                            }
                            if (IsInside(matrix, row + 2, col - 1) && matrix[row + 2, col - 1] == 'K')
                            {
                                currentCount++;
                            }
                            if (IsInside(matrix, row - 1, col - 2) && matrix[row - 1, col - 2] == 'K')
                            {
                                currentCount++;
                            }
                            if (IsInside(matrix, row + 1, col - 2) && matrix[row + 1, col - 2] == 'K')
                            {
                                currentCount++;
                            }
                            if (IsInside(matrix, row + 1, col + 2) && matrix[row + 1, col + 2] == 'K')
                            {
                                currentCount++;
                            }
                            if (IsInside(matrix, row - 1, col + 2) && matrix[row - 1, col + 2] == 'K')
                            {
                                currentCount++;
                            }
                        }
                        if (currentCount > maxCount)
                        {
                            maxCount = currentCount;
                            knightRow = row;
                            knightCol = col;
                        }
                    }
                }
                if (maxCount == 0)
                {
                    break;
                }
                matrix[knightRow, knightCol] = '0';
                totalHorsesCount++;
            }

            Console.WriteLine(totalHorsesCount);
        }

        private static bool IsInside(char[,] matrix, int wantedRow, int wantedCol)
        {
            return wantedRow < matrix.GetLength(0) && wantedRow >= 0
                && wantedCol < matrix.GetLength(1) && wantedCol >= 0;
        }
    }
}