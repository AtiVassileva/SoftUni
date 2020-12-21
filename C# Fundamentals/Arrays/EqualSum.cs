using System;
using System.Linq;

namespace EqualSum
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var isFound = false;

            for (var curr = 0; curr < array.Length; curr++)
            {
                var rightSum = 0;

                for (var i = curr + 1; i < array.Length; i++)
                {
                    rightSum += array[i];
                }
                var leftSum = 0;

                for (var i = curr - 1; i >= 0; i--)
                {
                    leftSum += array[i];
                }
                if (rightSum == leftSum)
                {
                    Console.WriteLine(curr);
                    isFound = true;
                }

            }
            if (isFound == false)
            {
                Console.WriteLine("no");
            }
        }
    }
}