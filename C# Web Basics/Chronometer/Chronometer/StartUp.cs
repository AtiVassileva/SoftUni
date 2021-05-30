using System;
using Chronometer.Core;

namespace Chronometer
{
    public class StartUp
    {
        public static void Main()
        {
            var chronometer = new Models.Chronometer();

            try
            {
                var engine = new Engine(chronometer);
                engine.Run();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}