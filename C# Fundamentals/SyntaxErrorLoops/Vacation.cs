using System;

namespace Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            var peopleCount = decimal.Parse(Console.ReadLine());
            var typeOfGroup = Console.ReadLine();
            var day = Console.ReadLine();
            var pricePerPerson = 0;
            var totalPrice = 0;

            if (typeOfGroup == "Students")
            {
                switch (day)
                {
                    case "Friday":
                        pricePerPerson = 8.45M;
                        break;
                    case "Saturday":
                        pricePerPerson = 9.8M;
                        break;
                    case "Sunday":
                        pricePerPerson = 10.46M;
                        break;
                }
            }
            else if (typeOfGroup == "Business")
            {
                switch (day)
                {
                    case "Friday":
                        pricePerPerson = 10.9M;
                        break;
                    case "Saturday":
                        pricePerPerson = 15.6M;
                        break;
                    case "Sunday":
                        pricePerPerson = 16;
                        break;
                }

            }
            else if (typeOfGroup == "Regular")
            {
                switch (day)
                {
                    case "Friday":
                        pricePerPerson = 15;
                        break;
                    case "Saturday":
                        pricePerPerson = 20;
                        break;
                    case "Sunday":
                        pricePerPerson = 22.5M;
                        break;
                }
            }
            totalPrice = pricePerPerson * peopleCount;

            if (typeOfGroup == "Students" && peopleCount >= 30)
            {
                totalPrice *= 0.85M;
            }
            if (typeOfGroup == "Business" && peopleCount >= 100)
            {
                totalPrice -= pricePerPerson * 10;
            }
            if (typeOfGroup == "Regular" && (peopleCount >= 10 && peopleCount <= 20))
            {
                totalPrice *= 0.95M;
            }

            Console.WriteLine($"Total price: {totalPrice:f2}");
        }
    }
}