using System;
using System.Threading;

namespace MilitaryElite.Exceptions
{
    public class InvalidMissionStateException : Exception
    {
        private const string ExceptionDefaultMessage =
            "Invalid mission state!";

        public InvalidMissionStateException() :
            base(ExceptionDefaultMessage)
        {
        }

        public InvalidMissionStateException(string message)
        : base(message)
        {
        }
    }
}
