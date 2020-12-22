using System;
using System.Collections.Generic;

namespace OldestFamilyMember
{
    class Program
    {
        static void Main(string[] args)
        {
            var count = int.Parse(Console.ReadLine());
            var allMembers = new List<Family>();

            for (var i = 0; i < count; i++)
            {
                var input = Console.ReadLine().Split();
                var name = input[0];
                var age = int.Parse(input[1]);

                var currentMember = new Family(name, age);
                allMembers.Add(currentMember);
            }

            var maxAge = 0;
            var oldest = "";

            foreach (var member in allMembers)
            {
                if (member.Age > maxAge)
                {
                    maxAge = member.Age;
                    oldest = member.Name;
                }
            }

            Console.WriteLine($"{oldest} {maxAge}");
        }
    }

    class Family
    {
        public Family(string name, int age)
        {
            this.Name = name;
            this.Age = age;
            List<Family> allMembers = new List<Family>();
        }

        public string Name { get; set; }
        public int Age { get; set; }
        List<string> members = new List<string>();
    }
}