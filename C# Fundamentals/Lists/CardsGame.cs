using System;
using System.Linq;
using System.Collections.Generic;

namespace CardsGame
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstPlayerCards = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            var secondPlayerCards = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            while (true)
            {
                if (firstPlayerCards.Count == 0 || secondPlayerCards.Count == 0)
                {
                    break;
                }
                if (firstPlayerCards[0] > secondPlayerCards[0])
                {
                    firstPlayerCards.Add(firstPlayerCards[0]);
                    firstPlayerCards.Add(secondPlayerCards[0]);
                }
                else if (secondPlayerCards[0] > firstPlayerCards[0])
                {
                    secondPlayerCards.Add(secondPlayerCards[0]);
                    secondPlayerCards.Add(firstPlayerCards[0]);
                }
                firstPlayerCards.RemoveAt(0);
                secondPlayerCards.RemoveAt(0);
            }
            if (firstPlayerCards.Sum() > secondPlayerCards.Sum())
            {
                Console.WriteLine($"First player wins! Sum: {firstPlayerCards.Sum()}");
            }
            else
            {
                Console.WriteLine($"Second player wins! Sum: {secondPlayerCards.Sum()}");
            }
        }
    }
}