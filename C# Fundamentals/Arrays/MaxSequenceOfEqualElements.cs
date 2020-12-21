using System;

namespace MaxSequenceOfEqualElements
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = Console.ReadLine().Split();
            var bestCount = 0;
            var bestIndex = 0;

            for (var i = 0; i < arr.Length; i++)
            {
                var current = arr[i];
                var counter = 1;

                for (var j = i + 1; j < arr.Length; j++)
                {
                    if (current == arr[j])
                    {
                        counter++;
                    }
                    else
                    {
                        break;
                    }
                }
                if (counter > bestCount)
                {
                    bestCount = counter;
                    bestIndex = i;
                }
            }

            var result = string.Empty;
            for (var i = 0; i < bestCount; i++)
            {
                result += arr[bestIndex] + " ";
            }
            Console.WriteLine(result);
        }
    }
}