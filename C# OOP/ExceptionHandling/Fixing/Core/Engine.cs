using System;

namespace Fixing.Core
{
    public class Engine
    {
        public void Run()
        {
            var weekdays = this.InitializeArray();

            try
            {
                for (var i = 0; i <= 5; i++)
                {
                    Console.WriteLine(weekdays[i]);
                }
            }
            catch (IndexOutOfRangeException ioe)
            {
                Console.WriteLine(ioe.Message);
            }
        }

        private string[] InitializeArray()
        {
            var weekdays = new[]
            {
                "Sunday",
                "Monday",
                "Tuesday",
                "Wednesday",
                "Thursday"
            };

            return weekdays;
        }
    }
}
