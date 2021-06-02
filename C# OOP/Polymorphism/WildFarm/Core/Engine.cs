using System;
using System.Collections.Generic;
using System.Linq;
using WildFarm.Models;

namespace WildFarm.Core
{
    public class Engine
    {
        private List<Animal> animals;
        
        private const string EndOfInput = "End";

        public Engine()
        {
            this.animals = new List<Animal>();
            

        }
        public void Run()
        {
            string line;

            while ((line = Console.ReadLine()) != EndOfInput)
            {
                var animalsArgs = line.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                var foodArgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                var animalType = animalsArgs[0];
                var name = animalsArgs[1];
                var weight = double.Parse(animalsArgs[2]);

                Animal currentAnimal = null;

                switch (animalType)
                {
                    case "Owl":
                        var wingSize = double.Parse(animalsArgs[3]);
                        currentAnimal = new Owl(name, weight, wingSize );
                        break;
                    case "Cat":
                        var livingRegion = animalsArgs[3];
                        var breed = animalsArgs[4];
                        currentAnimal = new Cat(name, weight, livingRegion, breed);
                        break;
                    case "Tiger":
                        var livingReg = animalsArgs[3];
                        var tigerBreed = animalsArgs[4];
                        currentAnimal = new Tiger(name, weight, livingReg, tigerBreed);
                        break;
                    case "Hen":
                        var wingSizes = double.Parse(animalsArgs[3]);
                        currentAnimal = new Hen(name, weight, wingSizes);
                        break;
                    case "Mouse":
                        var region = animalsArgs[3];
                        currentAnimal = new Mouse(name, weight, region);
                        break;
                    case "Dog":
                        var currentReg = animalsArgs[3];
                        currentAnimal = new Dog(name, weight, currentReg);
                        break;
                    default:
                        Console.WriteLine("Invalid animal!");
                        break;
                }
                
                this.animals.Add(currentAnimal);

                var foodType = foodArgs[0];
                var quantity = int.Parse(foodArgs[1]);

                Food currentFood = null;

                switch (foodType)
                {
                    case "Vegetable":
                        currentFood = new Vegetable(quantity);
                        break;
                    case "Fruit":
                        currentFood = new Fruit(quantity);
                        break;
                    case "Meat":
                        currentFood = new Meat(quantity);
                        break;
                    case "Seeds":
                        currentFood = new Seeds(quantity);
                        break;
                }
                Console.WriteLine(currentAnimal.Eat(currentFood));
            }

            foreach (var animal in this.animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
