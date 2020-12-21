using System;

namespace DaysOfTheWeek
{
    class Program
    {
        static void Main(string[] args)
        {
            var daysOfWeek = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
            var day = int.Parse(Console.ReadLine());

            if (day > 7 || day < 1)
            {
                Console.WriteLine("Invalid day!");
            }
            else
            {
                Console.WriteLine(daysOfWeek[day - 1]);
            }
        }
    }
}