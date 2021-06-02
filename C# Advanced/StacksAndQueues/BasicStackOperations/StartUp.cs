using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicStackOperation
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var givenNums = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var numbersToPush = input[0];
            var numsToPop = input[1];
            var searchedNum = input[2];
            var stack = new Stack<int>();

            if (numbersToPush == givenNums.Length)
            {
                stack = new Stack<int>(givenNums);
            }

            for (int i = 0; i < numsToPop; i++)
            {
                if (stack.Any())
                {
                    stack.Pop();
                }
            }

            if (stack.Count == 0)
            {
                Console.WriteLine("0");
            }
            if (stack.Contains(searchedNum) && stack.Any())
            {
                Console.WriteLine("true");
            }
            else if (!stack.Contains(searchedNum) && stack.Any())
            {
                Console.WriteLine(stack.Min());
            }
        }
    }
}