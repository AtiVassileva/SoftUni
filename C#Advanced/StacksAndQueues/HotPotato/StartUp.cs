using System;
using System.Collections.Generic;

namespace HotPotato
{
    class Program
    {
        static void Main(string[] args)
        {
            var children = Console.ReadLine().Split();
            var toss = int.Parse(Console.ReadLine());

            var queue = new Queue<string>(children);

            while (queue.Count > 1)
            {
                var currentName = queue.Dequeue();


                var currentIndex = 1;
                if (currentIndex == toss)
                {
                    Console.WriteLine($"Removed {currentName}");
                    currentIndex = 0;
                }
                else
                {
                    queue.Enqueue(currentName);
                }

                currentIndex++;
            }

            Console.WriteLine($"Last is {queue.Dequeue()}");
        }
    }
}