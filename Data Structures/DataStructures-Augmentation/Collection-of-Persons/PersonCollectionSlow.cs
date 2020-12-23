using System.Linq;
using System.Text.RegularExpressions;

namespace Collection_of_Persons
{
    using System;
    using System.Collections.Generic;

    public class PersonCollectionSlow : IPersonCollection
    {
        private readonly List<Person> people;

        public PersonCollectionSlow()
        {
            this.people = new List<Person>();
        }

        public bool AddPerson(string email, string name, int age, string town)
        {
            var person = this.people.FirstOrDefault(p => p.Email == email);

            if (person == null)
            {
                this.people.Add(new Person(email, name, age, town));
            }

            return person == null;
        }

        public int Count => this.people.Count;

        public Person FindPerson(string email)
        {
            return this.people.FirstOrDefault(p => p.Email == email);
        }

        public bool DeletePerson(string email)
        {
            var person = this.people.FirstOrDefault(p => p.Email == email);
            if (person != null)
            {
                this.people.Remove(person);
            }

            return person != null;
        }

        public IEnumerable<Person> FindPersons(string emailDomain)
        {
            return this.people.FindAll(p => p.Email.Split('@')[1] == emailDomain)
                .OrderBy(p => p, new PersonComparer());
        }

        public IEnumerable<Person> FindPersons(string name, string town)
        {
            return this.people.FindAll(p => p.Name == name && p.Town == town)
                .OrderBy(p => p, new PersonComparer());
        }

        public IEnumerable<Person> FindPersons(int startAge, int endAge)
        {
            return this.people.FindAll(p => p.Age >= startAge && p.Age <= endAge)
                .OrderBy(p => p, new PersonComparer());
        }

        public IEnumerable<Person> FindPersons(int startAge, int endAge, string town)
        {
            return this.people.FindAll(p => p.Age >= startAge && p.Age <= endAge && p.Town == town)
                .OrderBy(p => p, new PersonComparer());
        }
    }
}
