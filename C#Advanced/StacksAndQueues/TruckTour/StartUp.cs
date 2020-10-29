using System;
using System.Linq;
using System.Collections.Generic;

namespace TruckTour
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var count = int.Parse(Console.ReadLine());
            var pumps = new Queue<int[]>();

            FillQueue(count, pumps);

            var counter = 0;

            ReturnResult(count, pumps, counter);
        }

        private static void ReturnResult(int count, Queue<int[]> pumps, int counter)
        {
            while (true)
            {
                var fuelAmount = 0;
                var flag = true;

                for (var i = 0; i < count; i++)
                {
                    var currentPump = pumps.Dequeue();

                    fuelAmount += currentPump[0];

                    if (fuelAmount < currentPump[1])
                    {
                        flag = false;
                    }

                    fuelAmount -= currentPump[1];
                    pumps.Enqueue(currentPump);
                }

                if (flag)
                {
                    break;
                }

                counter++;
                pumps.Enqueue(pumps.Dequeue());
            }

            Console.WriteLine(counter);
        }

        private static void FillQueue(int count, Queue<int[]> pumps)
        {
            for (var i = 0; i < count; i++)
            {
                var currPump = Console.ReadLine().Split().Select(int.Parse).ToArray();
                pumps.Enqueue(currPump);
            }
        }
    }
}