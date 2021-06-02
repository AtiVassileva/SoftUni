using System;

namespace PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            var rows = long.Parse(Console.ReadLine());
            var paskalArray = new long[rows][];
            paskalArray[0] = new long[1];
            paskalArray[0][0] = 1;

            for (var row = 1; row < paskalArray.Length; row++)
            {
                paskalArray[row] = new long[row + 1];
                paskalArray[row][0] = 1;
                paskalArray[row][paskalArray[row].Length - 1] = 1;

                for (var col = 1; col < paskalArray[row].Length - 1; col++)
                {
                    paskalArray[row][col] = paskalArray[row - 1][col] + paskalArray[row - 1][col - 1];

                }
            }

            foreach (var row in paskalArray)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}