using System;
using System.Linq;
using System.Collections.Generic;

namespace FashionBotique
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var clothes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var rackCapacity = int.Parse(Console.ReadLine());
            var clothesStack = new Stack<int>(clothes);

            var racks = 1;
            var sum = 0;

            while (clothesStack.Any())
            {
                sum += clothesStack.Peek();

                if (sum <= rackCapacity)
                {
                    clothesStack.Pop();
                }
                else
                {
                    racks++;
                    sum = 0;
                }
            }
            Console.WriteLine(racks);
        }
    }
}