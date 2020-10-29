using System;
using System.Collections.Generic;

namespace Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            var clients = new Queue<string>();

            while (true)
            {
                var name = Console.ReadLine();
                if (name == "End")
                {
                    break;
                }

                if (name == "Paid")
                {
                    Console.WriteLine(string.Join("\n", clients));
                    clients.Clear();
                }
                else
                {
                    clients.Enqueue(name);
                }
            }

            Console.WriteLine($"{clients.Count} people remaining.");
        }
    }
}