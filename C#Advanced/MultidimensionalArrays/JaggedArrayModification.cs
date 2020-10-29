using System;
using System.Linq;

namespace JaggedArrayModification
{
    class Program
    {
        static void Main(string[] args)
        {
            var rows = int.Parse(Console.ReadLine());
            var jaggedArray = new int[rows][];

            for (int i = 0; i < rows; i++)
            {
                var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                jaggedArray[i] = input;

            }
            while (true)
            {
                var line = Console.ReadLine();
                if (line.ToLower() == "end")
                {
                    break;
                }
                var input = line.Split();
                var operatorCommand = input[0];
                var currRow = int.Parse(input[1]);
                var curColl = int.Parse(input[2]);
                var currValue = int.Parse(input[3]);

                if (currRow < 0 || currRow >= jaggedArray.Length || curColl < 0 || curColl >= jaggedArray[currRow].Length)
                {
                    Console.WriteLine("Invalid coordinates");
                    continue;
                }

                if (operatorCommand == "Add")
                {
                    jaggedArray[currRow][curColl] += currValue;
                }
                else if (operatorCommand == "Subtract")
                {
                    jaggedArray[currRow][curColl] -= currValue;
                }
            }

            foreach (var item in jaggedArray)
            {
                Console.WriteLine(string.Join(" ", item));
            }
        }
    }
}