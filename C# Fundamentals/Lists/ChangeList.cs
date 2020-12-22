using System;
using System.Linq;
using System.Collections.Generic;

namespace ChangeList
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            while (true)
            {
                var line = Console.ReadLine();
                if (line == "end")
                {
                    break;
                }

                var input = line.Split();
                switch (input[0])
                {
                    case "Delete":
                        var numToDelete = int.Parse(input[1]);

                        for (var i = 0; i < numbers.Count; i++)
                        {
                            if (numbers[i] == numToDelete)
                            {
                                numbers.Remove(numToDelete);
                            }
                        }
                        break;
                    case "Insert":
                        var element = int.Parse(input[1]);
                        var index = int.Parse(input[2]);
                        numbers.Insert(index, element);
                        break;
                }
            }
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}