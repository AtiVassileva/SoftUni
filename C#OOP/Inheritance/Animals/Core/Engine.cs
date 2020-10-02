using System;
using System.Collections.Generic;
using System.Linq;
using Animals.Models;

namespace Animals.Core
{
    public class Engine
    {
        private List<Animal> animals;

        public Engine()
        {
            this.animals = new List<Animal>();
        }
        public void Run()
        {
            while (true)
            {
                var animalType = Console.ReadLine();

                if (animalType == "Beast!")
                {
                    break;
                }

                var animalArgs = Console.ReadLine().
                    Split(" ", StringSplitOptions.RemoveEmptyEntries).
                    ToArray();

                var name = animalArgs[0];
                var age = int.Parse(animalArgs[1]);
                var gender = string.Empty;

                if (animalArgs.Length == 3)
                {
                    gender = animalArgs[2];
                }

                try
                {
                    var currentAnimal = CreateAnimal(animalType, name, age, gender);

                    animals.Add(currentAnimal);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
                
            }

            PrintAnimals();
        }

        private void PrintAnimals()
        {
            foreach (var animal in animals)
            {
                Console.WriteLine(animal.GetType().Name);
                Console.WriteLine(animal);
                Console.WriteLine(animal.ProduceSound());
            }
        }

        private Animal CreateAnimal(string animalType, string name, int age, string gender)
        {
            var currentAnimal = animalType switch

            {
                "Dog" => (Animal) new Dog(name, age, gender),
                "Cat" => new Cat(name, age, gender),
                "Frog" => new Frog(name, age, gender),
                "Kitten" => new Kitten(name, age),
                "Tomcat" => new Tomcat(name, age),
                _ => throw new ArgumentException("Invalid input!")
            };

            return currentAnimal;
        }
    }
}
