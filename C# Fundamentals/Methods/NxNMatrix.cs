using System;

namespace NxNMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            var num = int.Parse(Console.ReadLine());
            PrintMatrix(num);
        }

        static void PrintMatrix(int count)
        {
            for (var i = 0; i < count; i++)
            {
                for (var j = 0; j < count; j++)
                {
                    Console.Write(count + " ");
                }
                Console.WriteLine();
            }
        }
    }
}