using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snake_Moves
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var rows = numbers[0];
            var cols = numbers[1];
            var matrix = new char[rows, cols];

            var snake = Console.ReadLine();
            var counter = 0;
            var queue = new Queue<char>();

            int capacity = rows * cols;

            for (var row = 0; row < snake.Length; row++)
            {
                queue.Enqueue(snake[row]);
                counter++;

                if (counter == capacity)
                {
                    break;
                }
                if (row == snake.Length - 1)
                {
                    row = -1;
                }
            }

            for (var col = 0; col < rows; col++)
            {
                if (col % 2 == 0)
                {
                    for (var i = 0; i < cols; i++)
                    {
                        matrix[col, i] = queue.Dequeue();
                    }
                }
                else if (col % 2 != 0)
                {
                    for (var k = cols - 1; k > -1; k--)
                    {
                        matrix[col, k] = queue.Dequeue();
                    }
                }

            }

            for (var row = 0; row < matrix.GetLength(0); row++)
            {
                for (var col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write("{0}", matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}