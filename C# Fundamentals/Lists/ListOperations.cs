using System;
using System.Collections.Generic;
using System.Linq;

namespace ListOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            string line;
            line = Result(numbers);
            Console.WriteLine(string.Join(" ", numbers));
        }

        private static string Result(List<int> numbers)
        {
            string line;
            while ((line = Console.ReadLine()) != "End")
            {
                var command = line.Split();
                switch (command[0])
                {
                    case "Add":
                        AddMethod(numbers, command);
                        break;
                    case "Insert":
                        InsertMethod(numbers, command);
                        break;
                    case "Remove":
                        RemoveMethod(numbers, command);
                        break;
                    case "Shift":
                        ShiftLeftOrRight(numbers, command);
                        break;
                }

            }

            return line;
        }

        private static void ShiftLeftOrRight(List<int> numbers, string[] command)
        {
            var count = int.Parse(command[2]);
            count = count % numbers.Count;

            if (command[1] == "left")
            {
                for (var i = 0; i < count; i++)
                {
                    numbers.Add(numbers[0]);
                    numbers.RemoveAt(0);
                }
            }
            else
            {
                for (var i = 0; i < count; i++)
                {
                    numbers.Insert(0, numbers.Last());
                    numbers.RemoveAt(numbers.Count - 1);
                }
            }
        }

        private static void RemoveMethod(List<int> numbers, string[] command)
        {
            var indexToRemove = int.Parse(command[1]);
            if (indexToRemove >= 0 && indexToRemove < numbers.Count)
            {
                numbers.RemoveAt(indexToRemove);
            }
            else
            {
                Console.WriteLine("Invalid index");
            }
        }

        private static void InsertMethod(List<int> numbers, string[] command)
        {
            var number = int.Parse(command[1]);
            var index = int.Parse(command[2]);

            if (index >= 0 && index < numbers.Count)
            {
                numbers.Insert(index, number);
            }
            else
            {
                Console.WriteLine("Invalid index");
            }
        }

        private static void AddMethod(List<int> numbers, string[] command)
        {
            var numToAdd = int.Parse(command[1]);
            numbers.Add(numToAdd);
        }
    }
}