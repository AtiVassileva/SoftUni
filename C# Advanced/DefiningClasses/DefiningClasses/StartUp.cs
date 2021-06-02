using System;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var count = int.Parse(Console.ReadLine());

            var family = new Family();

            for (int i = 0; i < count; i++)
            {
                var personArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                var name = personArgs[0];
                var age = int.Parse(personArgs[1]);

                var person = new Person(name, age);
                family.AddMember(person);
            }

            var result = family.GetOldestMember();
            Console.WriteLine(result);
        }
    }
}