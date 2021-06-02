using System;
using SquareRoot.Common;
using SquareRoot.Contracts;

namespace SquareRoot.Core
{
    public class Engine
    {
        private const string EndMessage = "Goodbye";

        private readonly ICalculator calculator;

        public Engine(ICalculator calculator)
        {
            this.calculator = calculator;
        }

        public void Run()
        {
            try
            {
                var input = Console.ReadLine();
                var canCalculate = double.TryParse(input, out var number);

                if (!canCalculate)
                {
                    var message = ExceptionMessages.InvalidNumberExceptionMessage;
                    throw new InvalidOperationException(message);
                }

                var result = this.calculator.CalculateSquareRoot(number);
                Console.WriteLine($"{result:F2}");
            }

            catch(InvalidOperationException ioe)
            {
                Console.WriteLine(ioe.Message);
            }

            finally
            {
                Console.WriteLine(EndMessage);
            }
        }
    }
}
