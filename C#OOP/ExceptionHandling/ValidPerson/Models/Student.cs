using System;
using System.Linq;
using ValidPerson.Common;
using ValidPerson.Exceptions;

namespace ValidPerson.Models
{
    public class Student
    {
        private string name;
        private string email;

        public Student(string name, string email)
        {
            this.Name = name;
            this.Email = email;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (value.ToCharArray().Any(c => !char.IsLetter(c)) || string.IsNullOrWhiteSpace(value))
                {
                    throw new InvalidPersonNameException();
                }

                this.name = value;
            }
        }

        public string Email
        {
            get => this.email;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    var message = string.Format
                        (ExceptionMessages.InvalidNameExceptionMessage, "Email");
                   
                    throw new ArgumentNullException(message); 
                }

                this.email = value;
            }
        }
    }
}
