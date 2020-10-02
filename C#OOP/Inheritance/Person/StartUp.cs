using System;

namespace Person
{
    public class StartUp
    {
        public static void Main()
        {
            var name = Console.ReadLine();
            var age = int.Parse(Console.ReadLine());

            var child = new Child(name, age);
            Console.WriteLine(child);

        }
    }
}
