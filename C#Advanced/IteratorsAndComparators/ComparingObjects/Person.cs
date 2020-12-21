using System;
using System.Collections.Generic;

namespace ComparingObjects
{
    public class Person : IComparable<Person>
    {
        public Person(string name, int age, string town)
        {
            this.Name = name;
            this.Age = age;
            this.Town = town;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public string Town { get; set; }

        public int matched = 0;
        public int unmatched = 0;
        public int total = 0;

        public int CompareTo(Person otherPerson)
        {
            var res = 1;

            if (otherPerson != null)
            {
                res = this.Name.CompareTo(otherPerson.Name);
                if (res == 0)
                {
                    res = this.Age.CompareTo(otherPerson.Age);
                    if (res == 0)
                    {
                        res = this.Town.CompareTo(otherPerson.Town);
                    }
                }
            }

            return res;
        }
    }
}