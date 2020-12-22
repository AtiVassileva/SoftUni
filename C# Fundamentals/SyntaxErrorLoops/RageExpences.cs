using System;

namespace RageExpences
{
    class Program
    {
        static void Main(string[] args)
        {
            var lostGamesCount = int.Parse(Console.ReadLine());
            var headsetPrice = double.Parse(Console.ReadLine());
            var mousePrice = double.Parse(Console.ReadLine());
            var keyboardPrice = double.Parse(Console.ReadLine());
            var displayPrice = double.Parse(Console.ReadLine());

            var brokenHeadsets = 0;
            var brokenMouses = 0;
            var brokenKeyboards = 0;
            var brokenDisplays = 0;

            for (var i = 1; i <= lostGamesCount; i++)
            {
                if (i % 2 == 0)
                {
                    brokenHeadsets++;
                }
                if (i % 3 == 0)
                {
                    brokenMouses++;
                }
                if (i % 2 == 0 && i % 3 == 0)
                {
                    brokenKeyboards++;

                    if (brokenKeyboards != 0 && brokenKeyboards % 2 == 0)
                    {
                        brokenDisplays++;
                    }
                }
            }
            var expences = (brokenDisplays * displayPrice) + (brokenHeadsets * headsetPrice) + (brokenKeyboards * keyboardPrice) + (brokenMouses * mousePrice);
            Console.WriteLine($"Rage expenses: {expences:f2} lv.");
        }
    }
}
