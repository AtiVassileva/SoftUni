using System;
using System.Linq;
using System.Collections.Generic;

namespace MaximumAndMinimumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            var count = int.Parse(Console.ReadLine());
            var stack = new Stack<int>();

            for (var i = 0; i < count; i++)
            {
                var constraints = Console.ReadLine().Split().Select(int.Parse).ToArray();

                switch (constraints[0])
                {
                    case 1:
                        stack.Push(constraints[1]);
                        break;
                    case 2:
                        if (stack.Any())
                        {
                            stack.Pop();
                        }
                        break;
                    case 3:
                        if (stack.Any())
                        {
                            Console.WriteLine(stack.Max());
                        }
                        break;
                    case 4:
                        if (stack.Any())
                        {
                            Console.WriteLine(stack.Min());
                        }
                        break;
                }
            }

            Console.WriteLine(string.Join(", ", stack));
        }
    }
}