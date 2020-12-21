using System;
using System.Collections.Generic;

namespace GenericBoxOfString
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var count = int.Parse(Console.ReadLine());
            var values = new List<double>();

            for (var i = 0; i < count; i++)
            {
                var input = double.Parse(Console.ReadLine());
                values.Add(input);
            }

            var result = new Box<double>(values);

            var element = double.Parse(Console.ReadLine());
            Console.WriteLine(result.CountGreaterElements(values, element));
        }
    }
}