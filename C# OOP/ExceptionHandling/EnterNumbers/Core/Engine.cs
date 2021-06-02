using System;
using EnterNumbers.Common;

namespace EnterNumbers.Core
{
    public class Engine
    {
        public void Run()
        {
            Console.Write("Enter lower board: ");
            var start = int.Parse(Console.ReadLine());

            Console.Write("Enter upper board: ");
            var end = int.Parse(Console.ReadLine());

            for (var i = 0; i < 10; i++)
            {
                try
                {
                    ReadNumber(start, end);
                    Console.WriteLine("Success!");
                }

                catch (ArgumentOutOfRangeException ore)
                {
                    Console.WriteLine(ore.Message);
                    break;
                }

                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }
            }
        }

        private void ReadNumber(int start, int end)
        {
            if (start > end)
            {
                var message = ExceptionMessages.GreaterLbThanHbExceptionMessage;
                throw new ArgumentOutOfRangeException(message);
            }

            var input = Console.ReadLine();

            var canParse = int.TryParse(input, out var number);

            if (!canParse)
            {
                var message = ExceptionMessages.InvalidParseExceptionMessage;
                throw new InvalidOperationException(message);
            }

            var isInRange = number >= start && number <= end;

            if (!isInRange)
            {
                var message = ExceptionMessages.NotInRangeExceptionMessage;
                throw new InvalidOperationException(message);
            }

        }
    }
}
