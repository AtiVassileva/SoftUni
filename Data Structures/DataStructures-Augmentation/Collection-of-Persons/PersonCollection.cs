using System.Linq;
using Wintellect.PowerCollections;

namespace Collection_of_Persons
{
    using System;
    using System.Collections.Generic;

    public class PersonCollection : IPersonCollection
    {
        private readonly Dictionary<string, Person> peopleByEmail;
        private readonly Dictionary<string, SortedSet<Person>> peopleByEmailDomain;
        private readonly Dictionary<string, SortedSet<Person>> peopleByNameTown;
        private SortedDictionary<int, Dictionary<string, SortedSet<Person>>> peopleByAgeTown;

        public PersonCollection()
        {
            this.peopleByEmail = new Dictionary<string, Person>();
            this.peopleByEmailDomain = new Dictionary<string, SortedSet<Person>>();
            this.peopleByNameTown = new Dictionary<string, SortedSet<Person>>();
            this.peopleByAgeTown = new SortedDictionary<int, Dictionary<string, SortedSet<Person>>>();
        }
        public bool AddPerson(string email, string name, int age, string town)
        {
            if (this.FindPerson(email) != null)
            {
                return false;
            }

            var person = new Person(email, name, age, town);
            this.peopleByEmail[email] = person;

            var currentDomain = email.Split('@')[1];
            this.peopleByEmailDomain.AppendValueToKey(currentDomain, person);

            var nameAndTown = this.GetNameAndTown(person);
            this.peopleByNameTown.AppendValueToKey(nameAndTown, person);

            this.peopleByAgeTown.EnsureKeyExists(age);
            this.peopleByAgeTown[age].AppendValueToKey(town, person);

            return true;
        }

        public int Count => this.peopleByEmail.Count;

        public Person FindPerson(string email)
        {
            if (this.peopleByEmail.ContainsKey(email))
            {
                return this.peopleByEmail[email];
            }

            return null;
        }

        public bool DeletePerson(string email)
        {
            var person = this.FindPerson(email);

            if (person == null)
            {
                return false;
            }

            this.peopleByEmail.Remove(email);
            
            var currentDomain = email.Split('@')[1];
            this.peopleByEmailDomain[currentDomain].Remove(person);

            var nameTown = this.GetNameAndTown(person);
            this.peopleByNameTown[nameTown].Remove(person);

            this.peopleByAgeTown[person.Age][person.Town].Remove(person);

            return true;
        }

        public IEnumerable<Person> FindPersons(string emailDomain)
        {
            return this.peopleByEmailDomain.GetValuesForKey(emailDomain);
        }

        public IEnumerable<Person> FindPersons(string name, string town)
        {
            var nameTown = $"{name}_{town}";
            return this.peopleByNameTown.GetValuesForKey(nameTown)
                .OrderBy(p => p, new PersonComparer());
        }

        public IEnumerable<Person> FindPersons(int startAge, int endAge)
        {
            var ages = new SortedSet<int>(this.peopleByAgeTown.Keys);
            var matches = ages.GetViewBetween(startAge, endAge);

            return matches.SelectMany(k => this.peopleByAgeTown[k].Values.SelectMany(v => v))
                .OrderBy(p => p, new PersonComparer());
        }

        public IEnumerable<Person> FindPersons(int startAge, int endAge, string town)
        {
            var ages = new SortedSet<int>(this.peopleByAgeTown.Keys);
            var matches = ages.GetViewBetween(startAge, endAge);

            return matches.SelectMany(k => this.peopleByAgeTown[k].GetValuesForKey(town))
                .OrderBy(p => p, new PersonComparer());
        }

        private string GetNameAndTown(Person person)
        {
            return $"{person.Name}_{person.Town}";
        }
    }
}