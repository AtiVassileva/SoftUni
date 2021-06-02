using System;
using ValidPerson.Common;

namespace ValidPerson.Models
{
    public class Person
    {
        private const int MinAge = 0;
        private const int MaxAge = 120;

        private string firstName;
        private string lastName;
        private int age;

        public Person(string firstName, string lastName, int age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }

        public string FirstName
        {
            get => this.firstName;
            private set
            {
                this.CheckForInvalidName(value, "First name");
                this.firstName = value;
            }
        }

        public string LastName
        {
            get => this.lastName;
            private set
            {
                this.CheckForInvalidName(value, "Last name");
                this.lastName = value;
            }
        }

        public int Age
        {
            get => this.age;
            set
            {
                if (value < MinAge || value > MaxAge)
                {
                    var message = string.Format
                    (ExceptionMessages.InvalidAgeExceptionMessage,
                        MinAge, MaxAge);

                    throw new ArgumentOutOfRangeException(message);
                }

                this.age = value;
            }
        }

        private void CheckForInvalidName(string value, string nameType)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                var message = string.Format(ExceptionMessages.InvalidNameExceptionMessage, nameType);
                throw new ArgumentNullException(message);
            }
        }
    }
}
