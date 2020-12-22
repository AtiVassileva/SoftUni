using System;
using System.Linq;
using System.Collections.Generic;

namespace BombNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            var info = Console.ReadLine().Split().Select(int.Parse).ToList();

            var bombNum = info[0];
            var power = info[1];
            ReturnResult(numbers, bombNum, power);
            Console.WriteLine(numbers.Sum());

        }

        private static void ReturnResult(List<int> numbers, int bombNum, int power)
        {
            while (true)
            {
                var bombIndex = numbers.IndexOf(bombNum);
                var numbersCount = numbers.Count;
                if (bombIndex == -1)
                {
                    break;
                }
                RemoveRight(numbers, power, bombIndex, numbersCount);
                RemoveLeft(numbers, power, bombIndex);
            }
        }

        private static void RemoveLeft(List<int> numbers, int power, int bombIndex)
        {
            var leftIndex = bombIndex - power;
            for (var i = bombIndex - 1; i >= leftIndex; i--)
            {
                if (i >= 0)
                {
                    numbers.RemoveAt(i);
                }
                else
                {
                    break;
                }
            }
        }

        private static void RemoveRight(List<int> numbers, int power, int bombIndex, int numbersCount)
        {
            var rightIndex = bombIndex + power;
            for (var i = bombIndex; i <= rightIndex; i++)
            {
                if (i < numbersCount)
                {
                    numbers.RemoveAt(bombIndex);
                }
                else
                {
                    break;
                }
            }
        }
    }
}