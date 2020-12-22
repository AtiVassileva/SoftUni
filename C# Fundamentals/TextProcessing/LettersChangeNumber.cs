using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace LettersChangeNumber
{
    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            double totalSum = 0;

            foreach (var item in input)
            {
                if (item.Length > 1)
                {
                    var sum = 0;

                    var firstIndex = item[0];
                    var secondIndex = item[item.Length - 1];

                    var number = 0.0;

                    if (item.Length > 2)
                    {
                        try
                        {
                            number = double.Parse(item.Substring(1, item.Length - 2));
                        }
                        catch (Exception)
                        {
                            continue;
                        }
                    }

                    sum = GetFirstSum(firstIndex, number);
                    sum = GetSecondSum(secondIndex, sum);
                    totalSum += sum;
                }
            }

            Console.WriteLine($"{totalSum:f2}");
        }

        private static double GetSecondSum(char secondIndex, double sum)
        {
            var secondSum = sum;
            var pos = GetPosition(secondIndex);

            if (secondIndex >= 'a' && secondIndex <= 'z')
            {
                secondSum += pos;
            }
            else if (secondIndex >= 'A' && secondIndex <= 'Z')
            {
                secondSum -= pos;
            }

            return secondSum;
        }

        private static double GetFirstSum(char firstIndex, double number)
        {
            var sum = 0;
            var pos = GetPosition(firstIndex);

            if (firstIndex >= 'a' && firstIndex <= 'z')
            {
                sum = number * pos;
            }
            else if (firstIndex >= 'A' && firstIndex <= 'Z')
            {
                sum = number / pos;
            }

            return sum;
        }

        private static double GetPosition(char index)
        {
            var count = 0;

            var chek = char.ToLower(index);

            for (int i = 'a'; i <= 'z'; i++)
            {
                if (i > chek)
                {
                    break;
                }
                count++;
            }
            return count;
        }
    }
}