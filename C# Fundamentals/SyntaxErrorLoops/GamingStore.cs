using System;

namespace GamingStore
{
    class Program
    {
        static void Main(string[] args)
        {
            var budget = double.Parse(Console.ReadLine());
            var input = Console.ReadLine();
            var gamePrice = 0;
            var totalExpences = 0;
            var isBought = false;

            while (input != "Game Time")
            {
                string gameName = input;

                if (gameName == "Zplinter Zell")
                {
                    gamePrice = 19.99;
                }
                else if (gameName == "OutFall 4")
                {
                    gamePrice = 39.99;
                }
                else if (gameName == "CS: OG")
                {
                    gamePrice = 15.99;
                }
                else if (gameName == "Honored 2")
                {
                    gamePrice = 59.99;
                }
                else if (gameName == "RoverWatch")
                {
                    gamePrice = 29.99;
                }
                else if (gameName == "RoverWatch Origins Edition")
                {
                    gamePrice = 39.99;
                }
                else
                {
                    Console.WriteLine("Not found");
                    gamePrice = 0;
                }

                if (gamePrice > budget)
                {
                    Console.WriteLine("Too Expensive");
                }
                else if (gamePrice <= budget && gamePrice != 0)
                {
                    budget -= gamePrice;
                    totalExpences += gamePrice;
                    isBought = true;

                    if (isBought)
                    {
                        Console.WriteLine($"Bought {gameName}");
                    }

                }
                if (budget <= 0)
                {
                    Console.WriteLine("Out of money!");
                    break;
                }
                input = Console.ReadLine();
            }
            if (input == "Game Time" && budget > 0)
            {
                Console.WriteLine($"Total spent: ${totalExpences:f2}. Remaining: ${budget:f2}");
            }
        }
    }
}