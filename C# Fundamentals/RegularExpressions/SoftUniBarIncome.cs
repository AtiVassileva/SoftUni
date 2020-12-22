using System;
using System.Text.RegularExpressions;

namespace SoftUniBarIncome
{
    class Program
    {
        static void Main(string[] args)
        {
            var pattern = @"^%(?<customer>[A-Z][a-z]+)%[^|$%.]*<(?<product>\w+)>[^|$%.]*\|(?<count>\d+)\|[^|$%.]*?(?<price>[-+]?[0-9]*\.?[0-9]+([eE][-+]?[0-9]+)?)\$";
            var totalIncome = 0;

            while (true)
            {
                var line = Console.ReadLine();
                if (line == "end of shift")
                {
                    break;
                }

                if (Regex.IsMatch(line, pattern))
                {
                    var match = Regex.Match(line, pattern);
                    var name = match.Groups["customer"].Value;
                    var product = match.Groups["product"].Value;
                    var quantity = int.Parse(match.Groups["count"].Value);
                    var price = double.Parse(match.Groups["price"].Value);

                    var priceNow = price * quantity;

                    Console.WriteLine($"{name}: {product} - {priceNow:f2} ");
                    totalIncome += priceNow;
                }
            }

            Console.WriteLine($"Total income: {totalIncome:f2}");
        }
    }
}