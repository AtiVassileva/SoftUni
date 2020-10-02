using System;

namespace PersonsInfo
{
    public class Person
    {
        private const int MinNameLength = 3;
        private const int MinimumAge = 1;
        private const decimal MinSalary = 460m;

        private string _firstName;
        private string _lastName;
        private int _age;
        private decimal _salary;

        public Person(string firstName, string lastName, int age, decimal salary)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.Salary = salary;
        }

        public string FirstName 
        { 
            get => this._firstName;
            private set
            {
                CheckForInvalidName(value, "First");
                this._firstName = value;
            }
        }

        public string LastName 
        { 
            get => this._lastName;
            private set
            {
                CheckForInvalidName(value, "Last");
                this._lastName = value;
            }
        }

        public int Age
        {
            get => this._age;
            private set
            {
                if (value < MinimumAge)
                {
                    throw new ArgumentException(GlobalConstants.InvalidAgeExceptionMessage);
                }

                this._age = value;
            }
        }

        public decimal Salary
        {
            get => this._salary; 
            private set
            {
                if (value < MinSalary)
                {
                    throw new ArgumentException(GlobalConstants.InvalidSalaryExceptionMessage);
                }

                this._salary = value;
            }
        }
        
        public void IncreaseSalary(decimal percentage)
        {
            var delimiter = 100;
            if (this.Age < 30)
            {
                delimiter = 200;
            }

            this._salary += (this._salary * percentage) / delimiter;
        }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName} gets {this.Salary:F2} leva.";
        }

        private static void CheckForInvalidName(string value, string parameter)
        {
            if (value.Length < MinNameLength || string.IsNullOrWhiteSpace(value))
            {
                var message = string.Format(GlobalConstants.InvalidNameExceptionMessage, parameter);

                throw new ArgumentException(message);
            }
        }
    }
}
