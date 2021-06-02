using System;
using SquareRoot.Common;
using SquareRoot.Contracts;

namespace SquareRoot.Models
{
    public class SquareRootCalculator : ICalculator
    {
        public double CalculateSquareRoot(double number)
        {
            if (number < 0)
            {
                var message = ExceptionMessages.InvalidNumberExceptionMessage;
                throw new InvalidOperationException(message);
            }

            var result = Math.Sqrt(number);
            return result;
        }
    }
}
