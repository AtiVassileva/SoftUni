using System;
using System.Linq;
using System.Collections.Generic;

namespace StackSum
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputArr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var stack = new Stack<int>(inputArr);

            while (true)
            {
                var line = Console.ReadLine().ToLower();
                if (line == "end")
                {
                    break;
                }

                var command = line.Split();

                switch (command[0])
                {
                    case "add":
                        var first = int.Parse(command[1]);
                        var second = int.Parse(command[2]);
                        stack.Push(first);
                        stack.Push(second);
                        break;
                    case "remove":
                        var count = int.Parse(command[1]);

                        if (count < stack.Count)
                        {
                            for (var i = 0; i < count; i++)
                            {
                                stack.Pop();
                            }
                        }
                        break;
                }
            }

            Console.WriteLine($"Sum: {stack.Sum()}");
        }
    }
}