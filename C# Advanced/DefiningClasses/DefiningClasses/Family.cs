using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace DefiningClasses
{
    public class Family
    {
        private HashSet<Person> members;

        public Family()
        {
            this.members = new HashSet<Person>();
        }

        public void AddMember(Person member)
        {
            this.members.Add(member);
        }

        public Person GetOldestMember()
        {
            var oldestPerson = this.members.
                OrderByDescending(p => p.Age)
                .FirstOrDefault();
            return oldestPerson;
        }

        public HashSet<Person> GetAllPeopleAbove30()
        {
            return this.members.Where(p => p.Age > 30).OrderBy(x => x.Name).ToHashSet();
        }
    }
}