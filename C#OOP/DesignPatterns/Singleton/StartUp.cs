using System;
using Singleton.Core;

namespace Singleton
{
    public class StartUp
    {
        public static void Main()
        {
            var db = SingletonDataContainer.Instance;

            //Test if it gets correct data from file
            Console.WriteLine($"Sofia -> {db.GetPopulation("Sofia")}");
            Console.WriteLine($"London -> {db.GetPopulation("London")}");
            Console.WriteLine($"Washington, D.C. -> {db.GetPopulation("Washington, D.C.")}");
            Console.WriteLine($"Paris -> {db.GetPopulation("Paris")}");
            Console.WriteLine($"Rome -> {db.GetPopulation("Rome")}");
            Console.WriteLine($"Madrid -> {db.GetPopulation("Madrid")}");
        }
    }
}
