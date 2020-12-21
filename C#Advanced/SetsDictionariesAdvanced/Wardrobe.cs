using System;
using System.Collections.Generic;

namespace Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            var count = int.Parse(Console.ReadLine());
            var colorClothesCount = new Dictionary<string, Dictionary<string, int>>();
            var clothesCount = new Dictionary<string, int>();

            for (var i = 0; i < count; i++)
            {
                var input = Console.ReadLine().Split(" -> ");
                var currentColor = input[0];
                var currentClothes = input[1];

                if (!colorClothesCount.ContainsKey(currentColor))
                {
                    colorClothesCount.Add(currentColor, new Dictionary<string, int>());
                }

                foreach (var onePiece in currentClothes.Split(","))
                {
                    if (!colorClothesCount[currentColor].ContainsKey(onePiece))
                    {
                        colorClothesCount[currentColor].Add(onePiece, 0);
                    }
                    colorClothesCount[currentColor][onePiece]++;
                }
            }

            var wanted = Console.ReadLine().Split();
            var wantedColor = wanted[0];
            var wantedClothes = wanted[1];

            foreach (var kvp in colorClothesCount)
            {
                Console.WriteLine($"{kvp.Key} clothes:");

                foreach (var kvp1 in colorClothesCount[kvp.Key])
                {
                    if (kvp.Key == wantedColor && kvp1.Key == wantedClothes)
                    {
                        Console.WriteLine($"* {kvp1.Key} - {kvp1.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {kvp1.Key} - {kvp1.Value}");
                    }
                }
            }
        }
    }
}