using System;
using System.Linq;
using System.Collections.Generic;

namespace CupsAndBottles
{
    class Program
    {
        static void Main(string[] args)
        {

            var cupsQueues = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            var bottleStack = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());

            var wastedWater = 0;

            var cup = cupsQueues.Peek();
            while (cupsQueues.Any() && bottleStack.Any())
            {
                var bottle = bottleStack.Pop();

                if (bottle >= cup)
                {
                    bottle -= cup;
                    wastedWater += bottle;
                    cupsQueues.Dequeue();

                    if (cupsQueues.Count > 0)
                    {
                        cup = cupsQueues.Peek();
                    }
                }
                else
                {
                    cup -= bottle;
                }

            }

            if (bottleStack.Count > 0)
            {
                Console.WriteLine($"Bottles: {string.Join(" ", bottleStack)}");
            }
            else
            {
                Console.WriteLine($"Cups: {string.Join(" ", cupsQueues)}");
            }

            Console.WriteLine($"Wasted litters of water: {wastedWater}");
        }
    }
}