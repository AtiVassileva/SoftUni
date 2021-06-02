using System;
using System.Linq;

namespace ActionPrint
{
    class Program
    {
        static void Main(string[] args)
        {
            var printer = (name) =>
            {
                Console.WriteLine(name);
            };

            Console.ReadLine().
                Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList().ForEach(printer);
        }
    }
}