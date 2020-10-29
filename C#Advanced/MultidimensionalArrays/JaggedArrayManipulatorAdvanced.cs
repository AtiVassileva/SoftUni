using System;
using System.Linq;

namespace JaggedArrayManipulatorAdvanced
{
    class Program
    {
        private static bool x;

        static void Main(string[] args)
        {
            var rows = int.Parse(Console.ReadLine());

            var jaggedArray = new double[rows][];

            for (var row = 0; row < rows; row++)
            {
                var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
                jaggedArray[row] = input;
            }

            for (var row = 0; row < rows - 1; row++)
            {
                if (jaggedArray[row].Count() == jaggedArray[row + 1].Count())
                {
                    jaggedArray[row] = jaggedArray[row].Select(x => x * 2).ToArray();
                    jaggedArray[row + 1] = jaggedArray[row + 1].Select(x => x * 2).ToArray();

                }
                else
                {
                    jaggedArray[row] = jaggedArray[row].Select(x => x / 2).ToArray();
                    jaggedArray[row + 1] = jaggedArray[row + 1].Select(x => x / 2).ToArray();
                }
            }

            while (true)
            {
                var line = Console.ReadLine();
                if (line == "End")
                {
                    break;
                }

                var commandArgs = line.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                var commandType = commandArgs[0];
                var commandRow = int.Parse(commandArgs[1]);
                var commandCol = int.Parse(commandArgs[2]);
                var commandValue = double.Parse(commandArgs[3]);

                if (commandType == "Add")
                {
                    if (commandRow >= 0 && commandRow < jaggedArray.Length && commandCol >= 0 && commandCol < jaggedArray[commandRow].Length)
                    {
                        jaggedArray[commandRow][commandCol] += commandValue;
                    }
                }
                else if (commandType == "Subtract")
                {
                    if (commandRow >= 0 && commandRow < jaggedArray.Length && commandCol >= 0 && commandCol < jaggedArray[commandRow].Length)
                    {
                        jaggedArray[commandRow][commandCol] -= commandValue;
                    }
                }
            }

            for (var row = 0; row < rows; row++)
            {
                Console.WriteLine(string.Join(" ", jaggedArray[row]));
            }
        }
    }
}