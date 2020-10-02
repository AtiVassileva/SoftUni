using System;
namespace Telephony.Common
{
    public class InvalidNumberException : Exception
    {
        private const string ExceptionMessage = "Invalid number!";

        public InvalidNumberException() : base(ExceptionMessage)
        {
        }

        public InvalidNumberException(string message) : base(message)
        {
        }
    }
}
