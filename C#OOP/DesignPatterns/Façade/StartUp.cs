using System;
using Façade.Builders;
using Façade.Core;

namespace Façade
{
    public class StartUp
    {
        public static void Main()
        {
            var car = new CarBuilderFacade()
                .Info.
                WithType("Mazda")
                .WithColor("Dark Blue")
                .WithNumberOfDoors(5)
                .Built
                .WithCity("Tokio")
                .WithAddress("Japanese Tokio 39 st.")
                .Build;

            Console.WriteLine(car);
        }
    }
}
