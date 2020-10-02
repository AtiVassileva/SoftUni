using System;

namespace Telephony.Common
{
    public class InvalidWebsiteException : Exception
    {
        private const string ExceptionMessage = "Invalid URL!";

        public InvalidWebsiteException() : base(ExceptionMessage)
        {
        }

        public InvalidWebsiteException(string message) : base(message)
        {
        }
    }
}
