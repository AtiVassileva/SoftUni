using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace _8._Bombs
{
    class Program
    {
        static int[][] matrix;

        static void Main(string[] args)
        {
            var size = int.Parse(Console.ReadLine());
            matrix = new int[size][];

            FillMatrix();

            var bombs = Console.ReadLine().Split();
            var coordinate = new Queue<string>(bombs);

            Explosion(coordinate);

            var aliveCount = 0;
            var sum = 0;
            for (var row = 0; row < matrix.Length; row++)
            {
                for (var col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] > 0)
                    {
                        aliveCount++;
                        sum += matrix[row][col];
                    }
                }
            }

            Console.WriteLine($"Alive cells: {aliveCount}");
            Console.WriteLine($"Sum: {sum}");

            PrintMatrix();
        }
        private static void Explosion(Queue<string> coordinate)
        {
            while (coordinate.Count > 0)
            {
                var input = coordinate.Dequeue().Split(',').Select(int.Parse).ToArray();
                var row = input[0];
                var col = input[1];

                if (matrix[row][col] > 0)
                {
                    var bombPower = matrix[row][col];

                    if (IsToExplode(row - 1, col - 1)) matrix[row - 1][col - 1] -= bombPower;
                    if (IsToExplode(row - 1, col + 1)) matrix[row - 1][col + 1] -= bombPower;
                    if (IsToExplode(row, col - 1)) matrix[row][col - 1] -= bombPower;
                    if (IsToExplode(row, col + 1)) matrix[row][col + 1] -= bombPower;
                    if (IsToExplode(row + 1, col - 1)) matrix[row + 1][col - 1] -= bombPower;
                    if (IsToExplode(row + 1, col + 1)) matrix[row + 1][col + 1] -= bombPower;
                    if (IsToExplode(row - 1, col)) matrix[row - 1][col] -= bombPower;
                    if (IsToExplode(row + 1, col)) matrix[row + 1][col] -= bombPower;

                    matrix[row][col] = 0;
                }
            }
        }
        private static bool IsToExplode(int r, int c)
        {
            return r >= 0 && r < matrix.Length && c >= 0 && c < matrix[r].Length && matrix[r][c] > 0;
        }
        private static void PrintMatrix()
        {
            for (var row = 0; row < matrix.Length; row++)
            {
                Console.WriteLine(string.Join(" ", matrix[row]));
            }
        }
        private static void FillMatrix()
        {
            for (var row = 0; row < matrix.Length; row++)
            {
                matrix[row] = new int[matrix.Length];
                matrix[row] = Console.ReadLine().Split().Select(int.Parse).ToArray();
            }
        }
    }
}