using System;

namespace DateModifier
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var firstDate = DateTime.Parse(Console.ReadLine());
            var secondDate = DateTime.Parse(Console.ReadLine());
            var result = new DateModifier(firstDate, secondDate);
            Console.WriteLine(result.GetDayDifference(firstDate, secondDate));
        }
    }
}