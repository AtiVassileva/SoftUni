using System;

namespace Messages
{
    class Program
    {
        static void Main(string[] args)
        {
            var clicks = int.Parse(Console.ReadLine());
            var message = string.Empty;

            for (var i = 0; i < clicks; i++)
            {
                var digits = Console.ReadLine();
                var digitLength = digits.Length;
                var digit = digits[0] - '0';
                var offset = (digit - 2) * 3;

                if (digit == 0)
                {
                    message += (char)(digit + 32);
                    continue;
                }

                if (digit == 8 || digit == 9)
                {
                    offset++;
                }

                var letterIndex = offset + digitLength - 1;
                message += (char)(letterIndex + 97);
            }
            Console.WriteLine(message);
        }
    }
}