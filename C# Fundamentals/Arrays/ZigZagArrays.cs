using System;

namespace ZigZagArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            var count = int.Parse(Console.ReadLine());
            var arr1 = new string[count];
            var arr2 = new string[count];

            for (var i = 0; i < count; i++)
            {
                var current = Console.ReadLine().Split();

                if (i % 2 == 0)
                {
                    arr1[i] = current[0];
                    arr2[i] = current[1];
                }
                else
                {
                    arr1[i] = current[1];
                    arr2[i] = current[0];
                }
            }
            Console.WriteLine(string.Join(" ", arr1));
            Console.WriteLine(string.Join(" ", arr2));
        }
    }
}