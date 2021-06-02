
using System;

namespace Farm
{
    public class StartUp
    {
        public static void Main()
        {
            Console.WriteLine("1. Puppy");

            Puppy puppy = new Puppy();
            puppy.Eat();
            puppy.Bark();
            puppy.Weep();

            Console.WriteLine("2.Doggo");
            Dog dog = new Dog();
            dog.Eat();
            dog.Bark();

            Console.WriteLine("3.Cat:");
            Cat cat = new Cat();
            cat.Eat();
            cat.Meow();


        }
    }
}
