using System;

namespace ValidPerson.Exceptions
{
    public class InvalidPersonNameException : Exception
    {

        private const string DefaultMessage =
            "Name cannot contain any special character or numeric value!";

        public InvalidPersonNameException()
            : base(DefaultMessage)
        {
        }

        public InvalidPersonNameException(string message)
        : base(message)
        {
        }
    }
}
