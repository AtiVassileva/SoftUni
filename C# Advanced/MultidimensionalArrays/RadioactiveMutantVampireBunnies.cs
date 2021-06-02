using System;
using System.Collections.Generic;

namespace RadioactiveMutantVampireBunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            var sizes = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var rows = int.Parse(sizes[0]);
            var cols = int.Parse(sizes[1]);

            var matrix = new char[rows, cols];
            FillMatrix(matrix);

            var directions = Console.ReadLine();
            var playerCurrentRow = 0;
            var playerCurrentCol = 0;

            FindPlayerLocation(matrix, ref playerCurrentRow, ref playerCurrentCol);

            var hasWon = false;
            var isDead = false;
            foreach (var direction in directions)
            {
                var wantedRow = playerCurrentRow;
                var wantedCol = playerCurrentCol;

                if (direction == 'U')
                {
                    wantedRow--;
                }
                else if (direction == 'D')
                {
                    wantedRow++;
                }
                else if (direction == 'R')
                {
                    wantedCol++;
                }
                else if (direction == 'L')
                {
                    wantedCol--;
                }

                hasWon = IsOutsideTheMatrix(matrix, wantedRow, wantedCol);
                if (!hasWon)
                {
                    isDead = IsSymbol(matrix, 'B', wantedRow, wantedCol);
                    if (!isDead)
                    {

                        matrix[wantedRow, wantedCol] = 'P';

                    }
                    matrix[playerCurrentRow, playerCurrentCol] = '.';
                    playerCurrentRow = wantedRow;
                    playerCurrentCol = wantedCol;
                }
                else
                {
                    matrix[playerCurrentRow, playerCurrentCol] = '.';
                }

                var bunniesCoordinates = new List<int>();

                for (var row = 0; row < matrix.GetLength(0); row++)
                {
                    for (var col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (matrix[row, col] == 'B')
                        {
                            bunniesCoordinates.Add(row);
                            bunniesCoordinates.Add(col);
                        }
                    }
                }

                for (int i = 0; i < bunniesCoordinates.Count; i += 2)
                {
                    var bunnyRow = bunniesCoordinates[i];
                    var bunnyCol = bunniesCoordinates[i + 1];

                    SpreadBunnies(matrix, bunnyRow, bunnyCol);
                }
                isDead = IsSymbol(matrix, 'B', playerCurrentRow, playerCurrentCol);

                if (hasWon || isDead)
                {
                    break;
                }
            }

            PrintMatrix(matrix);

            if (hasWon)
            {
                Console.WriteLine($"won: {playerCurrentRow} {playerCurrentCol}");
            }
            else if (isDead)
            {
                Console.WriteLine($"dead: {playerCurrentRow} {playerCurrentCol}");
            }
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (var row = 0; row < matrix.GetLength(0); row++)
            {
                for (var col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static void SpreadBunnies(char[,] matrix, int bunnyRow, int bunnyCol)
        {
            if (bunnyRow - 1 >= 0)
            {
                matrix[bunnyRow - 1, bunnyCol] = 'B';
            }

            if (bunnyRow + 1 < matrix.GetLength(0))
            {
                matrix[bunnyRow + 1, bunnyCol] = 'B';
            }

            if (bunnyCol - 1 >= 0)
            {
                matrix[bunnyRow, bunnyCol - 1] = 'B';
            }

            if (bunnyCol + 1 < matrix.GetLength(1))
            {
                matrix[bunnyRow, bunnyCol + 1] = 'B';
            }
        }

        private static bool IsSymbol(char[,] matrix, char symbol, int wantedRow, int wantedCol)
        {
            var isBunny = false;
            if (matrix[wantedRow, wantedCol] == symbol)
            {
                isBunny = true;
            }
            return isBunny;
        }

        private static bool IsOutsideTheMatrix(char[,] matrix, int wantedRow, int wantedCol)
        {
            var isWon = true;
            if (wantedRow >= 0 && wantedRow < matrix.GetLength(0) && wantedCol >= 0 && wantedCol < matrix.GetLength(1))
            {
                isWon = false;
            }
            return isWon;
        }

        private static void FindPlayerLocation(char[,] matrix, ref int playerCurrentRow, ref int playerCurrentCol)
        {
            for (var row = 0; row < matrix.GetLength(0); row++)
            {
                for (var col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'P')
                    {
                        playerCurrentRow = row;
                        playerCurrentCol = col;
                    }
                }
            }
        }

        public static void FillMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var input = Console.ReadLine().ToCharArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }
        }

    }
}