using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace MultiplyBigNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstNum = Console.ReadLine().ToCharArray();
            var multiplier = int.Parse(Console.ReadLine());

            if (multiplier == 0)
            {
                Console.WriteLine(0);
                return;
            }

            var remainder = 0;

            var sb = new StringBuilder();

            for (int i = firstNum.Length - 1; i >= 0; i--)
            {
                var currentCh = firstNum[i];
                var currentNum = int.Parse(currentCh.ToString());

                var sum = (currentNum * multiplier) + remainder;
                sb.Append(sum % 10);
                remainder = sum / 10;

            }

            if (remainder != 0)
            {
                sb.Append(remainder);
            }

           var resultArr = sb.ToString().Reverse().ToList();
            RemoveZeros(resultArr);
            Console.WriteLine(string.Join("", resultArr));
        }

        private static void RemoveZeros(List<char> resultArr)
        {
            var endIndex = 0;

            if (resultArr[0] == 0)
            {
                for (var j = 1; j < resultArr.Count; j++)
                {
                    if (resultArr[j] != 0)
                    {
                        endIndex = j - 1;
                    }
                }
            }

            for (var i = 0; i < endIndex; i++)
            {
                resultArr.RemoveAt(0);
            }
        }
    }
}