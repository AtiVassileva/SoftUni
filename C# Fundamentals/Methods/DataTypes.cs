using System;

namespace DataTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            var dataType = Console.ReadLine();
            PrintDataType(dataType);
        }
        static void PrintDataType(string input)
        {
            if (input == "int")
            {
                var currentNum = int.Parse(Console.ReadLine());
                var result = currentNum * 2;
                Console.WriteLine(result);
            }
            else if (input == "real")
            {
                var currentNum = double.Parse(Console.ReadLine());
                var result = currentNum * 1.5;
                Console.WriteLine($"{result:f2}");
            }
            else
            {
                var currentInput = Console.ReadLine();
                Console.WriteLine($"${currentInput}$");
            }
        }
    }
}