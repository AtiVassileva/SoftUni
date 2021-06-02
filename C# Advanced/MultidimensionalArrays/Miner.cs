using System;
using System.Linq;

namespace Miner
{
    class Program
    {

        static void Main(string[] args)
        {
            var fieldSize = int.Parse(Console.ReadLine());

            var directions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            var matrix = new char[fieldSize, fieldSize];

            FillMatrix(matrix);
            var minerCurrentRow = 0;
            var minerCurrentCol = 0;
            var allCoals = 0;

            allCoals = FindAllCoals(matrix, allCoals);

            GetMinerStartPosition(matrix, ref minerCurrentRow, ref minerCurrentCol);

            foreach (var direction in directions)
            {
                var lastRow = 0;
                var lastCol = 0;

                if (direction == "up")
                {
                    if (minerCurrentRow < matrix.GetLength(0) && minerCurrentRow > 0)
                    {
                        minerCurrentRow--;
                        if (matrix[minerCurrentRow, minerCurrentCol] == 'e')
                        {
                            lastRow = minerCurrentRow;
                            lastCol = minerCurrentCol;
                            Console.WriteLine($"Game over! ({lastRow}, {lastCol})");
                            return;
                        }
                        else if (matrix[minerCurrentRow, minerCurrentCol] == 'c')
                        {
                            matrix[minerCurrentRow, minerCurrentCol] = '*';
                            allCoals--;
                            if (allCoals == 0)
                            {
                                lastRow = minerCurrentRow;
                                lastCol = minerCurrentCol;
                                Console.WriteLine($"You collected all coals! ({lastRow}, {lastCol})");
                                return;
                            }
                        }
                    }
                }

                else if (direction == "down")
                {
                    if (minerCurrentRow < matrix.GetLength(0) - 1 && minerCurrentRow > -1)
                    {
                        minerCurrentRow++;
                        if (matrix[minerCurrentRow, minerCurrentCol] == 'e')
                        {
                            lastRow = minerCurrentRow;
                            lastCol = minerCurrentCol;
                            Console.WriteLine($"Game over! ({lastRow}, {lastCol})");
                            return;
                        }
                        else if (matrix[minerCurrentRow, minerCurrentCol] == 'c')
                        {
                            matrix[minerCurrentRow, minerCurrentCol] = '*';
                            allCoals--;
                            if (allCoals == 0)
                            {
                                lastRow = minerCurrentRow;
                                lastCol = minerCurrentCol;
                                Console.WriteLine($"You collected all coals! ({lastRow}, {lastCol})");
                                return;
                            }
                        }
                    }
                }

                else if (direction == "right")
                {
                    if (minerCurrentCol < matrix.GetLength(1) - 1 && minerCurrentCol > -1)
                    {
                        minerCurrentCol++;
                        if (matrix[minerCurrentRow, minerCurrentCol] == 'e')
                        {
                            lastRow = minerCurrentRow;
                            lastCol = minerCurrentCol;
                            Console.WriteLine($"Game over! ({lastRow}, {lastCol})");
                            return;
                        }
                        else if (matrix[minerCurrentRow, minerCurrentCol] == 'c')
                        {
                            matrix[minerCurrentRow, minerCurrentCol] = '*';
                            allCoals--;
                            if (allCoals == 0)
                            {
                                lastRow = minerCurrentRow;
                                lastCol = minerCurrentCol;
                                Console.WriteLine($"You collected all coals! ({lastRow}, {lastCol})");
                                return;
                            }
                        }
                    }
                }

                else if (direction == "left")
                {
                    if (minerCurrentCol < matrix.GetLength(1) && minerCurrentCol > 0)
                    {
                        minerCurrentCol--;
                        if (matrix[minerCurrentRow, minerCurrentCol] == 'e')
                        {
                            lastRow = minerCurrentRow;
                            lastCol = minerCurrentCol;
                            Console.WriteLine($"Game over! ({lastRow}, {lastCol})");
                            return;
                        }
                        else if (matrix[minerCurrentRow, minerCurrentCol] == 'c')
                        {
                            matrix[minerCurrentRow, minerCurrentCol] = '*';
                            allCoals--;
                            if (allCoals == 0)
                            {
                                lastRow = minerCurrentRow;
                                lastCol = minerCurrentCol;
                                Console.WriteLine($"You collected all coals! ({lastRow}, {lastCol})");
                                return;
                            }
                        }
                    }

                }
            }

            Console.WriteLine($"{allCoals} coals left. ({minerCurrentRow}, {minerCurrentCol})");
        }

        public static int FindAllCoals(char[,] matrix, int allCoals)
        {
            for (var row = 0; row < matrix.GetLength(0); row++)
            {
                for (var col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'c')
                    {
                        allCoals++;
                    }
                }
            }

            return allCoals;
        }

        public static void GetMinerStartPosition(char[,] matrix, ref int minerCurrentRow, ref int minerCurrentCol)
        {
            for (var row = 0; row < matrix.GetLength(0); row++)
            {
                for (var col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 's')
                    {
                        minerCurrentRow = row;
                        minerCurrentCol = col;
                    }
                }
            }
        }

        public static void FillMatrix(char[,] matrix)
        {
            for (var row = 0; row < matrix.GetLength(0); row++)
            {
                var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();

                for (var col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }
        }
    }
}