using System;

namespace MultiplicationTable
{
    class Program
    {
        static void Main(string[] args)
        {
            var num = int.Parse(Console.ReadLine());
            var times = int.Parse(Console.ReadLine());

            do
            {
                Console.WriteLine($"{num} X {times} = {num * times}");
                times++;
            }
            while (times <= 10);
        }
    }
}