using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace GreaterOfTwoValues
{
    class Program
    {
        static void Main(string[] args)
        {
            var dataType = Console.ReadLine();

            switch (dataType)
            {
                case "int":
                    var first = int.Parse(Console.ReadLine());
                    var second = int.Parse(Console.ReadLine());
                    ResultInts(first, second); break;
                case "char":
                    var firstChar = char.Parse(Console.ReadLine());
                    var secondChar = char.Parse(Console.ReadLine());
                    ResultChars(firstChar, secondChar); break;
                case "string":
                    var firstInput = Console.ReadLine();
                    var secondInput = Console.ReadLine();
                    ResultStrings(firstInput, secondInput); break;
            }
        }

        static int ResultInts(int first, int second)
        {
            var result = Math.Max(first, second);
            Console.WriteLine(result);
            return result;
        }

        static char ResultChars(char first, char second)
        {
            var result = (char)Math.Max(first, second);
            Console.WriteLine(result);
            return result;
        }

        static string ResultStrings(string first, string second)
        {
            var result = string.Empty;
            var comparison = first.CompareTo(second);

            if (comparison >= 0)
            {
                result = first;
            }
            else
            {
                result = second;
            }
            Console.WriteLine(result);
            return result;
        }
    }
}