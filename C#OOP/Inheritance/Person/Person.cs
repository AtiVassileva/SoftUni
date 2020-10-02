using System.Text;

namespace Person
{
    public class Person
    {
        private const int MinAge = 0;
        private int _age;

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; }

        public int Age
        {
            get => this._age;
            protected set
            {
                if (value >= MinAge)
                {
                    this._age = value;
                }
            }
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append($"Name: {this.Name}, Age: {this.Age}");

            return stringBuilder.ToString();
        }

    }
}
