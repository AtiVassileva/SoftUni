using System;
using System.Linq;
using System.Collections.Generic;

namespace FastFood
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var foodAmount = int.Parse(Console.ReadLine());
            var orders = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var queue = new Queue<int>(orders);

            Console.WriteLine(queue.Max());
            var sum = 0;

            while (queue.Count > 0)
            {
                var current = queue.Peek();
                sum += current;

                if (sum <= foodAmount)
                {
                    queue.Dequeue();
                }
                else
                {
                    if (queue.Any())
                    {
                        Console.WriteLine($"Orders left: {string.Join(" ", queue.ToArray())}");
                    }
                    return;
                }
            }

            if (queue.Count == 0)
            {
                Console.WriteLine("Orders complete");
            }
        }
    }
}