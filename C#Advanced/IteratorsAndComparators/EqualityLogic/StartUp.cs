using System;
using System.Linq;
using System.Collections.Generic;

namespace EqualityLogic
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var count = int.Parse(Console.ReadLine());

            var sortedSet = new SortedSet<Person>();
            var hashSet = new HashSet<Person>();

            for (var i = 0; i < count; i++)
            {
                var info = Console.ReadLine().Split(" ").ToArray();
                var name = info[0];
                var age = int.Parse(info[1]);

                var currPerson = new Person(name, age);

                sortedSet.Add(currPerson);
                hashSet.Add(currPerson);
            }

            Console.WriteLine(sortedSet.Count);
            Console.WriteLine(hashSet.Count);
        }
    }
}