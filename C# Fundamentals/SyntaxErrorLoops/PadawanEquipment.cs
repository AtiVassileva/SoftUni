using System;

namespace PadawanEquipment
{
    class Program
    {
        static void Main(string[] args)
        {
            var budget = double.Parse(Console.ReadLine());
            var countOfStudents = int.Parse(Console.ReadLine());
            var lightsaberPrice = double.Parse(Console.ReadLine());
            var robePrice = double.Parse(Console.ReadLine());
            var beltPrice = double.Parse(Console.ReadLine());

            var moneyForLightSabers = lightsaberPrice * Math.Ceiling(countOfStudents * 1.1);

            var moneyForRobes = countOfStudents * robePrice;

            var moneyForBelts = beltPrice * countOfStudents - (countOfStudents / 6 * beltPrice);

            var neededSum = moneyForBelts + moneyForLightSabers + moneyForRobes;

            if (budget >= neededSum)
            {
                Console.WriteLine($"The money is enough - it would cost {neededSum:f2}lv.");
            }
            else
            {
                Console.WriteLine($"Ivan Cho will need {neededSum - budget:f2}lv more.");
            }
        }
    }
}