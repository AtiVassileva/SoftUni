using System;

namespace MilitaryElite.Exceptions
{
    public class InvalidMissionCompletionException : Exception
    {
        private const string DefaultExceptionMessage =
            "Mission already completed!";

        public InvalidMissionCompletionException()
            : base(DefaultExceptionMessage)
        {
        }

        public InvalidMissionCompletionException(string message)
            : base(message)
        {
        }
    }
}
