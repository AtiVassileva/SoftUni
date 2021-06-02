using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicQueueOperations
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var givenNums = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var numsToDequeue = input[1];
            var searchedElement = input[2];

            var queue = new Queue<int>(givenNums);

            RemoveFromQueue(numsToDequeue, queue);

            PrintResult(queue, searchedElement);
        }

        private static void PrintResult(Queue<int> queue, int searchedElement)
        {
            if (queue.Count == 0)
            {
                Console.WriteLine("0");
            }

            if (queue.Contains(searchedElement) && queue.Any())
            {
                Console.WriteLine("true");
            }
            else if (!queue.Contains(searchedElement) && queue.Any())
            {
                Console.WriteLine(queue.Min());
            }
        }

        private static void RemoveFromQueue(int numsToDequeue, Queue<int> queue)
        {
            for (var i = 0; i < numsToDequeue; i++)
            {
                if (queue.Any())
                {
                    queue.Dequeue();
                }
            }
        }
    }
}