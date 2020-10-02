using System;

namespace Animals.Models
{
    public class Animal
    {
        private const string InvalidInputExceptionMessage =
            "Invalid input!";

        private const int MinAge = 0;

        private string name;
        private int age;
        public Animal(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    ThrowException();
                }

                this.name = value;
            }
        }
        public int Age
        {
            get => this.age;
            private set
            {
                if (value < MinAge)
                {
                    ThrowException();
                }

                this.age = value;
            }
        }
        public string Gender { get;  }

        public virtual string ProduceSound()
        {
            return "";
        }
        public override string ToString()
        {
            return $"{this.Name} {this.Age} {this.Gender}";
        }

        private void ThrowException()
        {
            throw new ArgumentException(InvalidInputExceptionMessage);
        }
    }
}
