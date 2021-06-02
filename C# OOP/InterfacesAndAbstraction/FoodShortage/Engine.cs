using System;
using System.Collections.Generic;
using System.Linq;
using FoodShortage.Models;

namespace FoodShortage
{
    public class Engine
    {
        private const string EndOfInput = "End";

        private List<string> birthdays;

        public Engine()
        {
            this.birthdays = new List<string>();
        }
        public void Run()
        {

            var rebelBuyers = new HashSet<Rebel>();
            var citizenBuyers = new HashSet<Citizen>();

            var peopleCount = int.Parse(Console.ReadLine());

            AddBuyers(peopleCount, citizenBuyers, rebelBuyers);

            BuyFood(citizenBuyers, rebelBuyers);

            var amountOfFood = 0;

            amountOfFood = FindTotalAmountOfFood(citizenBuyers, amountOfFood, rebelBuyers);

            Console.WriteLine(amountOfFood);
        }

        private static int FindTotalAmountOfFood(HashSet<Citizen> citizenBuyers, int totalSum, HashSet<Rebel> rebelBuyers)
        {
            foreach (var cit in citizenBuyers)
            {
                totalSum += cit.Food;
            }

            foreach (var reb in rebelBuyers)
            {
                totalSum += reb.Food;
            }

            return totalSum;
        }

        private static void BuyFood(HashSet<Citizen> citizenBuyers, HashSet<Rebel> rebelBuyers)
        {
            while (true)
            {
                var name = Console.ReadLine();
                if (name == "End")
                {
                    break;
                }

                var currentCitizenBuyer = citizenBuyers.FirstOrDefault(b => b.Name == name);
                currentCitizenBuyer?.BuyFood();

                var currentRebelBuyer = rebelBuyers.FirstOrDefault(r => r.Name == name);
                currentRebelBuyer?.BuyFood();
            }
        }

        private static void AddBuyers(int peopleCount, HashSet<Citizen> citizenBuyers, HashSet<Rebel> rebelBuyers)
        {
            for (int i = 0; i < peopleCount; i++)
            {
                var args = Console.ReadLine().Split('<', '>', ' ').ToArray();

                var name = args[0];
                var age = int.Parse(args[1]);

                if (args.Length == 4)
                {
                    var id = args[2];
                    var birthday = args[3];

                    var citizen = new Citizen(name, age, id, birthday);
                    citizenBuyers.Add(citizen);
                }
                else if (args.Length == 3)
                {
                    var group = args[2];
                    var rebel = new Rebel(name, age, @group);
                    rebelBuyers.Add(rebel);
                }
            }
        }
    }
}
