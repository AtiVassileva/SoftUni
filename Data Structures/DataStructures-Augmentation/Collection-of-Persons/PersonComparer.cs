using System;
using System.Collections.Generic;
using System.Text;

namespace Collection_of_Persons
{
    internal class PersonComparer : IComparer<Person>
    { 
        public int Compare(Person x, Person y)
        {
            var comparer = x.Age.CompareTo(y.Age);
            return comparer == 0 ? x.Email.CompareTo(y.Email) : comparer;
        }
    }
}
