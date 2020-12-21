using System;

namespace ReverseArray
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = Console.ReadLine().Split(' ');

            for (var i = array.Length - 1; i >= 0; i--)
            {
                var needed = array[i];
                Console.Write(needed + " ");
            }
        }
    }
}