using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.Collections.Generic;

namespace keyRevolver
{
    class Program
    {
        static void Main(string[] args)
        {
            var costOfBullets = int.Parse(Console.ReadLine());

            var revolverSize = int.Parse(Console.ReadLine());

            var tokensbullets = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var bullets = new Stack<int>(tokensbullets);

            var tokensLocks = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var locks = new Stack<int>(tokensLocks.Reverse());

            var bounty = int.Parse(Console.ReadLine());
            var count = 0;
            var startBullets = bullets.Count;

            while (bullets.Count != 0 && locks.Count != 0)
            {
                var bullet = bullets.Pop();
                var currentlock = locks.Pop();
                count++;

                if (bullet <= currentlock)
                {
                    Console.WriteLine("Bang!");
                }
                else
                {
                    Console.WriteLine("Ping!");
                    locks.Push(currentlock);
                }

                if (bullets.Count == 0)
                {
                    break;
                }
                if (count == revolverSize)
                {
                    Console.WriteLine("Reloading!");
                    count = 0;
                }

            }

            if (locks.Count > 0)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
            else
            {
                var bulletsLeft = bullets.Count;
                var money = bounty - (costOfBullets * (startBullets - bulletsLeft));
                Console.WriteLine($"{bulletsLeft} bullets left. Earned ${money}");
            }
        }
    }
}