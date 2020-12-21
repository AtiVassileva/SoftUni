using System;
using System.Linq;

namespace KaminoFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var maxArr = new int[n];
            var maxIndex = 0;
            var maxSample = 1;
            var maxCount = 0;
            var currSample = 1;

            while (true)
            {
                var line = Console.ReadLine();
                if (line == "Clone them!")
                {
                    break;
                }

                var currArr = Console.ReadLine().Split("!", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                currSample++;

                var bestCurrentCount = 0;
                var bestCurrentIndex = 0;
                var bestCurrSum = 0;

                for (var i = 0; i < currArr.Length; i++)
                {
                    var current = currArr[i];
                    var currCount = 1;

                    if (current == 0)
                    {
                        continue;
                    }
                    for (var j = i + 1; j < currArr.Length; j++)
                    {
                        if (currArr[j] == 1)
                        {
                            currCount++;
                        }
                        else
                        {
                            break;
                        }
                    }
                    if (currCount > bestCurrentCount)
                    {
                        bestCurrentCount = currCount;
                        bestCurrentIndex = i;
                        bestCurrSum = currArr.Sum();
                    }
                }
                if (bestCurrentCount > maxCount || (bestCurrentCount == maxCount && maxIndex < bestCurrentIndex) || maxArr.Sum() < bestCurrSum)
                {
                    maxIndex = bestCurrentIndex;
                    maxCount = bestCurrentCount;
                    maxArr = currArr;
                    maxSample = currSample;
                }
            }

            Console.WriteLine($"Best DNA sample {maxSample} with sum: {maxArr.Sum()}.");
            Console.WriteLine(string.Join(" ", maxArr));
        }
    }
}