using System;

namespace DigitsLettersAndOthers
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var digits = "";
            var letters = "";
            var others = "";

            foreach (var symbol in input)
            {
                if (char.IsDigit(symbol))
                {
                    digits += symbol;
                }
                else if (char.IsLetter(symbol))
                {
                    letters += symbol;
                }
                else
                {
                    others += symbol;
                }
            }

            Console.WriteLine(digits);
            Console.WriteLine(letters);
            Console.WriteLine(others);
        }
    }
}