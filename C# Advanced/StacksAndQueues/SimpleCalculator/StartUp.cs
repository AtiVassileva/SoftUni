using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split();

            var result = new Stack<string>(input.Reverse());
            var sum = 0;

            while (result.Count > 1)
            {
                var firstNumber = int.Parse(result.Pop());
                var operation = result.Pop();
                var secondNumber = int.Parse(result.Pop());

                var tempRes = operation switch
                {
                    "+" => (firstNumber + secondNumber),
                    "-" => (firstNumber - secondNumber),
                    _ => 0
                };

                result.Push(tempRes.ToString());
            }

            Console.WriteLine(result.Pop());
        }
    }
}