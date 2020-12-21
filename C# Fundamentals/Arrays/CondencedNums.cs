using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace CondencedNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            while (array.Length > 1)
            {
                var condensed = new int[array.Length - 1];
                for (int i = 0; i < condensed.Length; i++)
                {
                    condensed[i] = array[i] + array[i + 1];
                }

                array = condensed;
            }

            Console.WriteLine(array[0]);
        }
    }
}