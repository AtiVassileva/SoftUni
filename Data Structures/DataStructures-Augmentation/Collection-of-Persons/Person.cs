using System;
using System.Collections.Generic;

namespace Collection_of_Persons
{
    public class Person : IComparable<Person>
    {
        public Person(string email, string name, int age, string town)
        {
            this.Email = email;
            this.Name = name;
            this.Age = age;
            this.Town = town;
        }

        public string Email { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Town { get; set; }

        public int CompareTo(Person other)
        {
            return string.Compare(this.Email, other.Email, StringComparison.Ordinal);
        }

        public override bool Equals(object obj)
        {
            var other = (Person) obj;

            return other != null && this.Email.Equals(other.Email);
        }

        public override int GetHashCode()
        {
            return this.Email.GetHashCode();
        }
    }
}
