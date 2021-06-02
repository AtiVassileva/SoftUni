using System;
using System.Linq;
using System.Collections.Generic;

namespace AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            var add = array =>
            {
                var result = new List<int>();
                foreach (var num in array)
                {
                    var current = num;
                    current++;
                    result.Add(current);
                }

                return result;
            };

            var multiply = array =>
            {
                var result = new List<int>();
                foreach (var num in array)
                {
                    var current = num;
                    current *= 2;
                    result.Add(current);
                }

                return result;
            };

            var subtract = array =>
            {
                var result = new List<int>();
                foreach (var num in array)
                {
                    var current = num;
                    current--;
                    result.Add(current);
                }

                return result;
            };

            var print = array =>
            {
                Console.WriteLine(string.Join(' ', array));
                return array;
            };

            var inputArr = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            while (true)
            {
                var command = Console.ReadLine();
                if (command == "end")
                {
                    break;
                }

                switch (command)
                {
                    case "add":
                        inputArr = add(inputArr).ToArray();
                        break;
                    case "subtract":
                        inputArr = subtract(inputArr).ToArray();
                        break;
                    case "multiply":
                        inputArr = multiply(inputArr).ToArray();
                        break;
                    case "print":
                        inputArr = print(inputArr);
                        break;
                }
            }
        }
    }
}