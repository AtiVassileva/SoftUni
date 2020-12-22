using System;
using System.Linq;
using System.Collections.Generic;

namespace Messaging
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine().Split().Select(int.Parse).ToList();
            nums.ToArray();
            var text = Console.ReadLine().Split().ToList();
            var result = new List<string>();

            for (var i = 0; i < nums.Count; i++)
            {
                var currentNum = nums[0];
                var current = 0;
                var sum = 0;

                while (currentNum > 0)
                {
                    current = currentNum % 10;
                    sum += current;
                    currentNum /= 10;

                }

                string currentChar;
                var currentWord = text[i].Split().ToArray();
                foreach (var item in currentWord)
                {
                    currentChar = item;

                    if (sum > text.Count)
                    {
                        var currentIndex = sum - text.Count - 1;
                        result.Add(currentWord[currentIndex]);
                    }
                    else
                    {
                        var needed = currentWord[sum];
                        result.Add(needed);
                    }
                }
            }
            foreach (var item in result)
            {
                Console.Write(item);
            }
        }
    }
}